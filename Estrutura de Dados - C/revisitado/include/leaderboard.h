#ifndef LEADERBOARD_H
#define LEADERBOARD_H

#include <stdbool.h>
#include <stddef.h>

#define LB_MAX_NAME 31

typedef struct {
    int day;
    int month;
    int year;
} lb_date;

typedef struct {
    char name[LB_MAX_NAME];
    int score;
    lb_date date;
} lb_entry;

/* Opaque: callers cannot reach past the API and corrupt the heap. */
typedef struct leaderboard leaderboard;

typedef enum {
    LB_OK = 0,
    LB_ADDED,
    LB_REPLACED_WORST,
    LB_REJECTED_NOT_BETTER,
    LB_NOT_FOUND,
    LB_INVALID_ARG,
    LB_OUT_OF_MEMORY
} lb_status;

const char *lb_status_text(lb_status status);

leaderboard *lb_create(size_t capacity);
void lb_destroy(leaderboard *lb);

size_t lb_size(const leaderboard *lb);
size_t lb_capacity(const leaderboard *lb);
bool lb_is_full(const leaderboard *lb);

bool lb_date_is_valid(lb_date date);

/* Adds while there is room; once full, replaces the worst entry only when the
   new score beats it. */
lb_status lb_submit(leaderboard *lb, const char *name, int score, lb_date date);

lb_status lb_worst(const leaderboard *lb, lb_entry *out);
lb_status lb_best(const leaderboard *lb, lb_entry *out);
lb_status lb_find(const leaderboard *lb, const char *name, lb_entry *out);
lb_status lb_remove(leaderboard *lb, const char *name);

/* Writes up to `max` entries ordered by score, highest first. */
size_t lb_ranking(const leaderboard *lb, lb_entry *out, size_t max);

#endif
