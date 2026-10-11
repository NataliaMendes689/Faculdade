CC      ?= gcc
CFLAGS  ?= -std=c17 -Wall -Wextra -Wpedantic -Wshadow -Wconversion -O2 -Iinclude
BUILD   := build

LIB_SRC  := src/leaderboard.c
APP_SRC  := src/main.c
TEST_SRC := tests/test_leaderboard.c

.PHONY: all test memcheck clean

all: $(BUILD)/leaderboard

test: $(BUILD)/tests
	./$(BUILD)/tests

memcheck: $(BUILD)/tests
	valgrind --error-exitcode=1 --leak-check=full --errors-for-leak-kinds=all ./$(BUILD)/tests

$(BUILD)/leaderboard: $(LIB_SRC) $(APP_SRC) | $(BUILD)
	$(CC) $(CFLAGS) $^ -o $@

$(BUILD)/tests: $(LIB_SRC) $(TEST_SRC) | $(BUILD)
	$(CC) $(CFLAGS) $^ -o $@

$(BUILD):
	mkdir -p $(BUILD)

clean:
	rm -rf $(BUILD)
