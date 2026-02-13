# 🧪 Sort Algorithm Demo

![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-latest-239120?logo=csharp)
![xUnit](https://img.shields.io/badge/tests-xUnit-512BD4)
![License](https://img.shields.io/badge/license-MIT-green)
![Built with GitHub Copilot](https://img.shields.io/badge/built%20with-GitHub%20Copilot-8957e5?logo=githubcopilot)

A small .NET 10 console app that benchmarks classic sorting algorithms using **BenchmarkDotNet** — built entirely as a playground for experimenting with **GitHub Copilot**.

## ✨ Purpose

This repo exists to explore what GitHub Copilot can do: generating algorithms, writing tests, refactoring code, and more. The sorting theme is just a convenient vehicle.

## 📂 Project Structure

| Path | Description |
|------|-------------|
| `SortAlgoDemo/` | Console app – generates a random array, runs every algorithm, and prints a comparison table. |
| `SortAlgoDemo.Tests/` | xUnit test project for verifying sort correctness. |

## 🔢 Algorithms Included

| Algorithm | Class |
|-----------|-------|
| Bubble Sort | `BubbleSort` |
| Selection Sort | `SelectionSort` |
| Insertion Sort | `InsertionSort` |
| Shell Sort | `ShellSort` |
| Merge Sort | `MergeSort` |
| Heap Sort | `HeapSort` |
| Quick Sort | `QuickSort` |
| Linq Sort | `LinqSort` |

All algorithms implement the shared `ISortAlgorithm` interface.

## 🚀 Getting Started

```bash
# clone the repo
git clone https://github.com/sneakpodbob/sortalgodemo.git
cd sortalgodemo

# run the benchmark (BenchmarkDotNet must run in `Release` configuration for reliable measurements)
dotnet run --project SortAlgoDemo -c Release

# run the tests
dotnet test
```

BenchmarkDotNet uses the `SortBenchmarks` runner to exercise each algorithm on the same seeded random dataset. The generated artifacts (HTML, Markdown, etc.) land in `SortAlgoDemo/BenchmarkResults`, so open the latest report after the benchmark finishes.

## 🛠️ Tech Stack

- **.NET 10** (console app)
- **xUnit** (unit tests)
- **GitHub Copilot** 🤖 (the real star of the show)

## 📄 License

This project is for learning and experimentation — use it however you like (MIT License).
