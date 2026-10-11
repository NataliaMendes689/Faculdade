#include "leaderboard.h"

#include <stdio.h>
#include <string.h>

static int failures = 0;
static int checks = 0;

#define CHECK(cond)                                                              \
    do {                                                                         \
        checks++;                                                                \
        if (!(cond)) {                                                           \
            failures++;                                                          \
            printf("  FAIL %s:%d  %s\n", __FILE__, __LINE__, #cond);             \
        }                                                                        \
    } while (0)

static const lb_date D = { 1, 1, 2026 };

static void test_create_and_capacity(void)
{
    CHECK(lb_create(0) == NULL);

    leaderboard *lb = lb_create(4);
    CHECK(lb != NULL);
    CHECK(lb_size(lb) == 0);
    CHECK(lb_capacity(lb) == 4);
    CHECK(!lb_is_full(lb));
    lb_destroy(lb);

    lb_destroy(NULL);
}

static void test_fills_then_keeps_only_better_scores(void)
{
    leaderboard *lb = lb_create(3);

    CHECK(lb_submit(lb, "ana", 10, D) == LB_ADDED);
    CHECK(lb_submit(lb, "bia", 50, D) == LB_ADDED);
    CHECK(lb_submit(lb, "caio", 30, D) == LB_ADDED);
    CHECK(lb_is_full(lb));

    CHECK(lb_submit(lb, "duda", 5, D) == LB_REJECTED_NOT_BETTER);
    CHECK(lb_submit(lb, "duda", 10, D) == LB_REJECTED_NOT_BETTER);
    CHECK(lb_size(lb) == 3);

    CHECK(lb_submit(lb, "duda", 40, D) == LB_REPLACED_WORST);
    CHECK(lb_size(lb) == 3);

    lb_entry e;
    CHECK(lb_find(lb, "ana", &e) == LB_NOT_FOUND);
    CHECK(lb_find(lb, "duda", &e) == LB_OK && e.score == 40);

    lb_destroy(lb);
}

static void test_worst_and_best(void)
{
    leaderboard *lb = lb_create(5);
    lb_entry e;

    CHECK(lb_worst(lb, &e) == LB_NOT_FOUND);
    CHECK(lb_best(lb, &e) == LB_NOT_FOUND);

    lb_submit(lb, "ana", 70, D);
    lb_submit(lb, "bia", 20, D);
    lb_submit(lb, "caio", 90, D);

    CHECK(lb_worst(lb, &e) == LB_OK && e.score == 20);
    CHECK(lb_best(lb, &e) == LB_OK && e.score == 90);

    lb_destroy(lb);
}

static void test_remove_keeps_the_heap_valid(void)
{
    leaderboard *lb = lb_create(6);
    const int scores[] = { 50, 10, 70, 30, 90, 20 };

    for (int i = 0; i < 6; i++) {
        char name[LB_MAX_NAME];
        snprintf(name, sizeof name, "p%d", i);
        lb_submit(lb, name, scores[i], D);
    }

    CHECK(lb_remove(lb, "nao-existe") == LB_NOT_FOUND);

    /* p1 holds 10, the heap root. Removing it must promote 20. */
    CHECK(lb_remove(lb, "p1") == LB_OK);
    CHECK(lb_size(lb) == 5);

    lb_entry e;
    CHECK(lb_worst(lb, &e) == LB_OK && e.score == 20);

    /* Remove from the middle: the replacement may need to sift either way. */
    CHECK(lb_remove(lb, "p0") == LB_OK);
    CHECK(lb_worst(lb, &e) == LB_OK && e.score == 20);
    CHECK(lb_best(lb, &e) == LB_OK && e.score == 90);
    CHECK(lb_size(lb) == 4);

    lb_destroy(lb);
}

static void test_ranking_is_sorted_desc(void)
{
    leaderboard *lb = lb_create(5);
    lb_submit(lb, "ana", 30, D);
    lb_submit(lb, "bia", 90, D);
    lb_submit(lb, "caio", 60, D);

    lb_entry out[5];
    size_t n = lb_ranking(lb, out, 5);

    CHECK(n == 3);
    CHECK(out[0].score == 90);
    CHECK(out[1].score == 60);
    CHECK(out[2].score == 30);

    /* A truncated request must still return the top entries. */
    n = lb_ranking(lb, out, 2);
    CHECK(n == 2);
    CHECK(out[0].score == 90);

    lb_destroy(lb);
}

static void test_dates(void)
{
    CHECK(lb_date_is_valid((lb_date){ 29, 2, 2024 }));
    CHECK(!lb_date_is_valid((lb_date){ 29, 2, 2023 }));
    CHECK(lb_date_is_valid((lb_date){ 29, 2, 2000 }));
    CHECK(!lb_date_is_valid((lb_date){ 29, 2, 1900 }));
    CHECK(!lb_date_is_valid((lb_date){ 31, 4, 2026 }));
    CHECK(!lb_date_is_valid((lb_date){ 0, 1, 2026 }));
    CHECK(!lb_date_is_valid((lb_date){ 1, 13, 2026 }));
}

static void test_rejects_bad_input(void)
{
    leaderboard *lb = lb_create(2);

    CHECK(lb_submit(NULL, "ana", 10, D) == LB_INVALID_ARG);
    CHECK(lb_submit(lb, NULL, 10, D) == LB_INVALID_ARG);
    CHECK(lb_submit(lb, "", 10, D) == LB_INVALID_ARG);
    CHECK(lb_submit(lb, "ana", 10, (lb_date){ 31, 2, 2026 }) == LB_INVALID_ARG);
    CHECK(lb_size(lb) == 0);

    lb_destroy(lb);
}

static void test_long_name_is_truncated_not_overflowed(void)
{
    leaderboard *lb = lb_create(1);
    char longname[128];
    memset(longname, 'x', sizeof longname - 1);
    longname[sizeof longname - 1] = '\0';

    CHECK(lb_submit(lb, longname, 10, D) == LB_ADDED);

    lb_entry e;
    CHECK(lb_worst(lb, &e) == LB_OK);
    CHECK(strlen(e.name) == LB_MAX_NAME - 1);

    lb_destroy(lb);
}

int main(void)
{
    test_create_and_capacity();
    test_fills_then_keeps_only_better_scores();
    test_worst_and_best();
    test_remove_keeps_the_heap_valid();
    test_ranking_is_sorted_desc();
    test_dates();
    test_rejects_bad_input();
    test_long_name_is_truncated_not_overflowed();

    printf("%d checks, %d failures\n", checks, failures);
    return failures == 0 ? 0 : 1;
}
