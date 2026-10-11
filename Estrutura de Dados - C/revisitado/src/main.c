#include "leaderboard.h"

#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <string.h>
#include <time.h>

#define CAPACITY 20

static bool read_line(char *buffer, size_t size)
{
    if (fgets(buffer, (int)size, stdin) == NULL) {
        return false;
    }

    buffer[strcspn(buffer, "\n")] = '\0';
    return true;
}

/* scanf leaves bad input in the stream and loops forever on a letter. */
static bool read_int(const char *prompt, int *out)
{
    char line[64];

    printf("%s", prompt);
    if (!read_line(line, sizeof line)) {
        return false;
    }

    char *end = NULL;
    long value = strtol(line, &end, 10);
    if (end == line || *end != '\0' || value < INT_MIN || value > INT_MAX) {
        printf("  not a number\n");
        return false;
    }

    *out = (int)value;
    return true;
}

static lb_date today(void)
{
    time_t now = time(NULL);
    struct tm *t = localtime(&now);
    lb_date d = { t->tm_mday, t->tm_mon + 1, t->tm_year + 1900 };
    return d;
}

static void print_entry(const lb_entry *e)
{
    printf("  %-20s %6d   %02d/%02d/%04d\n",
           e->name, e->score, e->date.day, e->date.month, e->date.year);
}

static void show_ranking(const leaderboard *lb)
{
    lb_entry rows[CAPACITY];
    size_t n = lb_ranking(lb, rows, CAPACITY);

    if (n == 0) {
        printf("  the board is empty\n");
        return;
    }

    printf("\n  %-4s %-20s %6s   %s\n", "#", "player", "score", "date");
    for (size_t i = 0; i < n; i++) {
        printf("  %-4zu", i + 1);
        print_entry(&rows[i]);
    }
}

static void play(leaderboard *lb)
{
    char name[LB_MAX_NAME];

    printf("name: ");
    if (!read_line(name, sizeof name) || name[0] == '\0') {
        printf("  a name is required\n");
        return;
    }

    int score = rand() % 101;
    printf("  you scored %d\n", score);

    lb_status status = lb_submit(lb, name, score, today());
    printf("  %s\n", lb_status_text(status));
}

static void show_one(const leaderboard *lb)
{
    char name[LB_MAX_NAME];
    lb_entry e;

    printf("name: ");
    if (!read_line(name, sizeof name)) {
        return;
    }

    if (lb_find(lb, name, &e) == LB_OK) {
        print_entry(&e);
    } else {
        printf("  %s\n", lb_status_text(LB_NOT_FOUND));
    }
}

static void show_extreme(const leaderboard *lb, bool best)
{
    lb_entry e;
    lb_status status = best ? lb_best(lb, &e) : lb_worst(lb, &e);

    if (status == LB_OK) {
        print_entry(&e);
    } else {
        printf("  the board is empty\n");
    }
}

static void drop(leaderboard *lb)
{
    char name[LB_MAX_NAME];

    printf("name: ");
    if (!read_line(name, sizeof name)) {
        return;
    }

    printf("  %s\n", lb_status_text(lb_remove(lb, name)));
}

int main(void)
{
    srand((unsigned)time(NULL));

    leaderboard *lb = lb_create(CAPACITY);
    if (lb == NULL) {
        fprintf(stderr, "could not allocate the leaderboard\n");
        return 1;
    }

    for (;;) {
        printf("\n  1 play            2 highest        3 lowest\n"
               "  4 find player     5 how many       6 ranking\n"
               "  7 remove player   8 quit\n");

        int option = 0;
        if (!read_int("\n  > ", &option)) {
            if (feof(stdin)) {
                break;
            }
            continue;
        }

        switch (option) {
        case 1: play(lb); break;
        case 2: show_extreme(lb, true); break;
        case 3: show_extreme(lb, false); break;
        case 4: show_one(lb); break;
        case 5: printf("  %zu of %zu\n", lb_size(lb), lb_capacity(lb)); break;
        case 6: show_ranking(lb); break;
        case 7: drop(lb); break;
        case 8: lb_destroy(lb); return 0;
        default: printf("  pick 1 to 8\n");
        }
    }

    lb_destroy(lb);
    return 0;
}
