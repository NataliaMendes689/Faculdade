# Leaderboard — revisited

The same exercise as `../Castlevania.c`: a score board with fixed capacity where, once
full, a new score only gets in if it beats the worst one already there.

Written again from scratch, as I would solve it today.

```bash
make test       # 49 checks
make memcheck   # valgrind, zero leaks
make && ./build/leaderboard
```

Builds clean under `-Wall -Wextra -Wpedantic -Wshadow -Wconversion`.

## What changed, and why

### The data structure now matches the problem

The original scans all 20 entries to find the worst one every time somebody plays.
The whole point of the exercise is the bounded board, and a bounded board that
discards its minimum is the textbook case for a **min-heap**: the worst entry is
always at index 0.

| Operation | Before | Now |
| --- | --- | --- |
| Find the worst | O(n) | O(1) |
| Insert when full | O(n) | O(log n) |
| Remove by name | O(n) + shift | O(n) + O(log n) |

At twenty players the difference is invisible. The reason to do it is that choosing
the structure that fits the problem is what the subject was about.

### A variable was defined in a header

```c
/* Castlevania.h */
int numJogadores = 0;
```

This compiles only because the project has a single `.c` file. Add a second one that
includes the header and the link fails with a duplicate symbol. It also made the
count global and writable from anywhere, while being passed around as a parameter at
the same time — two sources of truth for one number.

The size now lives inside the struct and is read through `lb_size()`.

### The type is opaque

`struct leaderboard` is declared in the header and defined in the `.c`. Callers hold
a pointer and cannot reach in and corrupt the heap invariant. The original exposed the
raw array, so any caller could reorder it and silently break every later operation.

### Input handling no longer traps the program

`scanf(" %d", &opcao)` leaves bad input in the buffer. Type a letter at that menu and
the original loops forever, reprinting the menu and rereading the same character.
Reading a whole line with `fgets` and parsing it with `strtol` ends the loop and
reports the problem.

### Nothing prints from inside the data structure

The original mixes `printf` into the logic, so the functions cannot be tested or
reused anywhere that is not a terminal. Operations now return an `lb_status` and the
caller decides what to show. That is what makes the test suite possible at all.

### Capacity is a parameter

`#define MAXJOGADORES 20` became an argument to `lb_create`, with the array allocated
to match and freed in `lb_destroy`.

### Names cannot overflow

`strcpy` into a `char[30]` with no length check becomes `snprintf`, which truncates.
The test suite feeds it a 127-character name and asserts the result fits.

### Dates are validated

Including leap years: 29 February 2024 is accepted, 2023 is not, 2000 is, 1900 is not.
The original never checked.

## Layout

```
include/leaderboard.h   the API
src/leaderboard.c       min-heap, no I/O
src/main.c              the menu
tests/test_leaderboard.c
```
