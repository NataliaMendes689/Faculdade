#include "leaderboard.h"

#include <stdio.h>

#include <stdlib.h>
#include <string.h>

struct leaderboard {
    lb_entry *heap; /* min-heap on score: the worst entry sits at index 0 */
    size_t size;
    size_t capacity;
};

static void swap(lb_entry *a, lb_entry *b)
{
    lb_entry tmp = *a;
    *a = *b;
    *b = tmp;
}

static void sift_up(leaderboard *lb, size_t i)
{
    while (i > 0) {
        size_t parent = (i - 1) / 2;
        if (lb->heap[parent].score <= lb->heap[i].score) {
            break;
        }
        swap(&lb->heap[parent], &lb->heap[i]);
        i = parent;
    }
}

static void sift_down(leaderboard *lb, size_t i)
{
    for (;;) {
        size_t left = 2 * i + 1;
        size_t right = left + 1;
        size_t smallest = i;

        if (left < lb->size && lb->heap[left].score < lb->heap[smallest].score) {
            smallest = left;
        }
        if (right < lb->size && lb->heap[right].score < lb->heap[smallest].score) {
            smallest = right;
        }
        if (smallest == i) {
            return;
        }

        swap(&lb->heap[i], &lb->heap[smallest]);
        i = smallest;
    }
}

static size_t index_of(const leaderboard *lb, const char *name)
{
    for (size_t i = 0; i < lb->size; i++) {
        if (strncmp(lb->heap[i].name, name, LB_MAX_NAME) == 0) {
            return i;
        }
    }
    return lb->size;
}

const char *lb_status_text(lb_status status)
{
    switch (status) {
    case LB_OK:                   return "ok";
    case LB_ADDED:                return "entry added";
    case LB_REPLACED_WORST:       return "replaced the worst entry";
    case LB_REJECTED_NOT_BETTER:  return "board is full and the score did not beat the worst";
    case LB_NOT_FOUND:            return "no such player";
    case LB_INVALID_ARG:          return "invalid argument";
    case LB_OUT_OF_MEMORY:        return "out of memory";
    default:                      return "unknown status";
    }
}

leaderboard *lb_create(size_t capacity)
{
    if (capacity == 0) {
        return NULL;
    }

    leaderboard *lb = malloc(sizeof *lb);
    if (lb == NULL) {
        return NULL;
    }

    lb->heap = malloc(capacity * sizeof *lb->heap);
    if (lb->heap == NULL) {
        free(lb);
        return NULL;
    }

    lb->size = 0;
    lb->capacity = capacity;
    return lb;
}

void lb_destroy(leaderboard *lb)
{
    if (lb == NULL) {
        return;
    }
    free(lb->heap);
    free(lb);
}

size_t lb_size(const leaderboard *lb) { return lb == NULL ? 0 : lb->size; }

size_t lb_capacity(const leaderboard *lb) { return lb == NULL ? 0 : lb->capacity; }

bool lb_is_full(const leaderboard *lb) { return lb != NULL && lb->size == lb->capacity; }

bool lb_date_is_valid(lb_date d)
{
    static const int days[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    if (d.month < 1 || d.month > 12 || d.year < 1970 || d.year > 9999 || d.day < 1) {
        return false;
    }

    int limit = days[d.month - 1];
    bool leap = (d.year % 4 == 0 && d.year % 100 != 0) || d.year % 400 == 0;
    if (d.month == 2 && leap) {
        limit = 29;
    }

    return d.day <= limit;
}

lb_status lb_submit(leaderboard *lb, const char *name, int score, lb_date date)
{
    if (lb == NULL || name == NULL || name[0] == '\0' || !lb_date_is_valid(date)) {
        return LB_INVALID_ARG;
    }

    lb_entry entry;
    memset(&entry, 0, sizeof entry);
    snprintf(entry.name, sizeof entry.name, "%s", name);
    entry.score = score;
    entry.date = date;

    if (lb->size < lb->capacity) {
        lb->heap[lb->size] = entry;
        sift_up(lb, lb->size);
        lb->size++;
        return LB_ADDED;
    }

    /* Full: index 0 is the worst score, so the comparison is O(1). */
    if (score <= lb->heap[0].score) {
        return LB_REJECTED_NOT_BETTER;
    }

    lb->heap[0] = entry;
    sift_down(lb, 0);
    return LB_REPLACED_WORST;
}

lb_status lb_worst(const leaderboard *lb, lb_entry *out)
{
    if (lb == NULL || out == NULL) {
        return LB_INVALID_ARG;
    }
    if (lb->size == 0) {
        return LB_NOT_FOUND;
    }

    *out = lb->heap[0];
    return LB_OK;
}

lb_status lb_best(const leaderboard *lb, lb_entry *out)
{
    if (lb == NULL || out == NULL) {
        return LB_INVALID_ARG;
    }
    if (lb->size == 0) {
        return LB_NOT_FOUND;
    }

    size_t best = 0;
    for (size_t i = 1; i < lb->size; i++) {
        if (lb->heap[i].score > lb->heap[best].score) {
            best = i;
        }
    }

    *out = lb->heap[best];
    return LB_OK;
}

lb_status lb_find(const leaderboard *lb, const char *name, lb_entry *out)
{
    if (lb == NULL || name == NULL || out == NULL) {
        return LB_INVALID_ARG;
    }

    size_t i = index_of(lb, name);
    if (i == lb->size) {
        return LB_NOT_FOUND;
    }

    *out = lb->heap[i];
    return LB_OK;
}

lb_status lb_remove(leaderboard *lb, const char *name)
{
    if (lb == NULL || name == NULL) {
        return LB_INVALID_ARG;
    }

    size_t i = index_of(lb, name);
    if (i == lb->size) {
        return LB_NOT_FOUND;
    }

    lb->size--;
    if (i != lb->size) {
        lb->heap[i] = lb->heap[lb->size];
        /* The moved entry can belong either way, so try both directions. */
        sift_up(lb, i);
        sift_down(lb, i);
    }

    return LB_OK;
}

static int by_score_desc(const void *a, const void *b)
{
    const lb_entry *x = a;
    const lb_entry *y = b;

    if (x->score != y->score) {
        return y->score - x->score;
    }
    return strncmp(x->name, y->name, LB_MAX_NAME);
}

size_t lb_ranking(const leaderboard *lb, lb_entry *out, size_t max)
{
    if (lb == NULL || out == NULL) {
        return 0;
    }

    size_t n = lb->size < max ? lb->size : max;
    memcpy(out, lb->heap, n * sizeof *out);
    qsort(out, n, sizeof *out, by_score_desc);
    return n;
}
