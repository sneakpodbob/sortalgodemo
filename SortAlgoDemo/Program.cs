using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using SortAlgoDemo.SortAlgos;
using SortAlgoDemo.SortAlgos.Interface;

var config = ManualConfig.Create(DefaultConfig.Instance)
    .AddExporter(HtmlExporter.Default)
    .WithArtifactsPath("BenchmarkResults");

BenchmarkRunner.Run<SortBenchmarks>(config);

[MemoryDiagnoser]
public class SortBenchmarks
{
    private const int Size = 100_000;
    private int[] _data = [];
    private ISortAlgorithm _algorithm = null!;

    public IEnumerable<string> AlgorithmNames =>
    [
        nameof(QuickSort),
        nameof(MergeSort),
        nameof(HeapSort),
        nameof(ShellSort),
        nameof(InsertionSort),
        nameof(SelectionSort),
        nameof(BubbleSort),
        nameof(LinqSort)
    ];

    [ParamsSource(nameof(AlgorithmNames))]
    public string AlgorithmName { get; set; } = string.Empty;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = new int[Size];
        var rng = new Random(42);
        for (var i = 0; i < Size; i++)
        {
            _data[i] = rng.Next();
        }

        _algorithm = AlgorithmName switch
        {
            nameof(QuickSort) => new QuickSort(),
            nameof(MergeSort) => new MergeSort(),
            nameof(HeapSort) => new HeapSort(),
            nameof(ShellSort) => new ShellSort(),
            nameof(InsertionSort) => new InsertionSort(),
            nameof(SelectionSort) => new SelectionSort(),
            nameof(BubbleSort) => new BubbleSort(),
            nameof(LinqSort) => new LinqSort(),
            _ => throw new ArgumentOutOfRangeException(nameof(AlgorithmName), AlgorithmName, "Unknown algorithm")
        };
    }

    [Benchmark]
    public int[] Sort()
    {
        var copy = (int[])_data.Clone();
        _algorithm.Sort(copy);
        return copy;
    }
}
