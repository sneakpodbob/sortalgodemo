using System.Diagnostics;
using SortAlgoDemo.SortAlgos;
using SortAlgoDemo.SortAlgos.Interface;

const int size = 100_000;

var original = new int[size];
Random rng = new(42);
for (var i = 0; i < size; i++)
    original[i] = rng.Next();

ISortAlgorithm[] algorithms =
[
    new QuickSort(),
    new MergeSort(),
    new HeapSort(),
    new ShellSort(),
    new InsertionSort(),
    new SelectionSort(),
    new BubbleSort()
];

Random.Shared.Shuffle(algorithms);

const int barWidth = 30;
var total = algorithms.Length;
var results = new (string Name, double Ms)[total];

Console.WriteLine($"Sorting {size:N0} random integers\n");
Console.WriteLine($"{"Algorithm",-18} {"Time",12}");
Console.WriteLine(new string('-', 31));

for (var i = 0; i < total; i++)
{
    var algorithm = algorithms[i];
    var name = algorithm.Name;
    var copy = (int[])original.Clone();

    // draw progress bar
    var filled = (int)((double)i / total * barWidth);
    var empty = barWidth - filled;
    Console.Write($"\r[{"█".PadRight(filled, '█')}{"░".PadRight(empty, '░')}] {i}/{total}  Running {name}...".PadRight(80));

    var sw = Stopwatch.StartNew();
    algorithm.Sort(copy);
    sw.Stop();

    results[i] = (name, sw.Elapsed.TotalMilliseconds);

    // clear progress line then print result
    Console.Write($"\r{"",-80}\r");
    Console.WriteLine($"{name,-18} {sw.Elapsed.TotalMilliseconds,9:N2} ms");
}

// final progress bar at 100%
Console.Write($"\r[{"█".PadRight(barWidth, '█')}] {total}/{total}  Done!".PadRight(80));
Console.WriteLine("\n");

// summary comparison table
var fastest = results.Min(r => r.Ms);

Console.WriteLine($"{"Algorithm",-18} {"Time",12} {"vs Fastest",14}");
Console.WriteLine(new string('-', 46));

foreach (var (name, ms) in results.OrderBy(r => r.Ms))
{
    var pct = ms / fastest * 100.0;
    var tag = pct <= 100.0 ? "(fastest)" : $"{pct,7:N1}%";
    Console.WriteLine($"{name,-18} {ms,9:N2} ms {tag,14}");
}
