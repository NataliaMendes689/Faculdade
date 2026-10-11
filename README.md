# Faculdade

Coursework from the Technology Degree in Analysis and Systems Development at
Faculdade de Tecnologia de Sorocaba.

Four disciplines, three languages, kept as a record of the path rather than as
finished products.

![C](https://img.shields.io/badge/C-A8B9CC?style=flat-square&logo=c&logoColor=black)
![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square)
![Java](https://img.shields.io/badge/Java-ED8B00?style=flat-square&logo=openjdk&logoColor=white)

## Contents

### `Estrutura de Dados - C`

A player-ranking system built on structs: registration, scoring, date handling,
sorting and searching, with the interface split across a header and its
implementation.

### `Linguagem de Programação I - C`

Thirty-three programs organised by topic, in the order the subject was taught:

| Folder | Topic |
| --- | --- |
| `1. Ciclo básico` | control flow, loops, I/O |
| `1.1 Beecrowd` | solutions to judge problems |
| `2. Vetor` | one-dimensional arrays |
| `3. Matriz` | matrices |
| `4. String` | string handling |
| `6. Struct` | records |
| `7. Ponteiros` | pointers |
| `8. Ordenação e Pesquisa` | sorting and searching |

### `Linguagem de Programação II - C#`

Eleven Windows Forms projects on .NET 5 — nine assignments, an extras folder and the
exam. Volume calculator, simple calculator, BMI, triangle classification, discount
calculation, classes and methods, and the later assignments that put them together.

### `Programação Orientada a Objetos - Java`

Eighteen NetBeans projects working through object orientation step by step:
classes and attributes, constructors, `this`, binary association, generalisation and
specialisation both with and without polymorphism, `ArrayList`, and two graded
assignments.

## Running it

**C** — any C99 compiler:

```bash
gcc programa.c -o programa && ./programa
```

**C#** — the projects target .NET 5 Windows Forms. On a current SDK, retarget first:

```bash
dotnet run --project Atividade\ 3/PCalcIMC/PCalcIMC/PCalcIMC.csproj
```

**Java** — NetBeans projects, or from the command line:

```bash
javac -d out src/**/*.java && java -cp out Main
```

## A note on the C# section

These projects were originally committed as `.rar` archives, which meant none of the
code was readable on GitHub — no syntax highlighting, no diffs, no search. The
archives have been unpacked and the source committed directly; build output
(`bin/`, `obj/`, `.vs/`) is excluded by `.gitignore` instead of being carried around
inside a compressed file.
