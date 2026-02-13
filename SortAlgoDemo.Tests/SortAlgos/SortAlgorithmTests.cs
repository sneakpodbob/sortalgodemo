using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.Tests.SortAlgos;

/// <summary>
/// Shared tests for every <see cref="ISortAlgorithm"/> implementation.
/// Implementations are discovered automatically via reflection, so adding a new
/// sort algorithm to the main project is all that is needed – no test changes required.
/// </summary>
public class SortAlgorithmTests
{
    /// <summary>
    /// Discovers all concrete <see cref="ISortAlgorithm"/> implementations in the
    /// production assembly and provides them as theory data.
    /// </summary>
    public static TheoryData<ISortAlgorithm> AllAlgorithms
    {
        get
        {
            var data = new TheoryData<ISortAlgorithm>();

            var types = typeof(ISortAlgorithm).Assembly
                .GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }
                         && typeof(ISortAlgorithm).IsAssignableFrom(t))
                .OrderBy(t => t.Name);

            foreach (var type in types)
                data.Add((ISortAlgorithm)Activator.CreateInstance(type)!);

            return data;
        }
    }

    // ───────────────────────────── Name property ─────────────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Name_ReturnsNonNullNonEmptyValue(ISortAlgorithm algorithm)
    {
        var name = algorithm.Name;

        Assert.NotNull(name);
        Assert.NotEmpty(name);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Name_IsConsistentAcrossMultipleAccesses(ISortAlgorithm algorithm)
    {
        var first = algorithm.Name;
        var second = algorithm.Name;

        Assert.Equal(first, second);
    }

    // ──────────────────────────── Edge cases ─────────────────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_NullArray_Throws(ISortAlgorithm algorithm)
    {
        int[]? array = null;

        var ex = Record.Exception(() => algorithm.Sort(array!));

        Assert.True(ex is NullReferenceException or ArgumentNullException,
            $"Expected NullReferenceException or ArgumentNullException but got {ex.GetType().Name}");
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_EmptyArray_DoesNotThrow(ISortAlgorithm algorithm)
    {
        var array = Array.Empty<int>();

        algorithm.Sort(array);

        Assert.Empty(array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_SingleElement_RemainsUnchanged(ISortAlgorithm algorithm)
    {
        var array = new[] { 42 };

        algorithm.Sort(array);

        Assert.Equal([42], array);
    }

    // ──────────────────────── Basic sorting scenarios ────────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_TwoElements_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var array = new[] { 2, 1 };

        algorithm.Sort(array);

        Assert.Equal([1, 2], array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_AlreadySorted_RemainsUnchanged(ISortAlgorithm algorithm)
    {
        var array = new[] { 1, 2, 3, 4, 5 };

        algorithm.Sort(array);

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_ReverseSorted_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var array = new[] { 5, 4, 3, 2, 1 };

        algorithm.Sort(array);

        Assert.Equal([1, 2, 3, 4, 5], array);
    }

    // ────────────────────── Duplicates & identical values ────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_WithDuplicates_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var array = new[] { 3, 1, 2, 3, 1 };

        algorithm.Sort(array);

        Assert.Equal([1, 1, 2, 3, 3], array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_AllSameElements_RemainsUnchanged(ISortAlgorithm algorithm)
    {
        var array = new[] { 7, 7, 7, 7 };

        algorithm.Sort(array);

        Assert.Equal([7, 7, 7, 7], array);
    }

    // ──────────────────────── Negative & boundary values ─────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_NegativeNumbers_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var array = new[] { -3, -1, -2, 0, 2 };

        algorithm.Sort(array);

        Assert.Equal([-3, -2, -1, 0, 2], array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_MinAndMaxValues_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var array = new[] { int.MaxValue, 0, int.MinValue };

        algorithm.Sort(array);

        Assert.Equal([int.MinValue, 0, int.MaxValue], array);
    }

    // ─────────────────────── Larger / randomised input ───────────────────────

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_LargeRandomArray_SortsCorrectly(ISortAlgorithm algorithm)
    {
        var random = new Random(42); // fixed seed for reproducibility
        var array = Enumerable.Range(0, 1_000)
            .Select(_ => random.Next(-1_000, 1_000))
            .ToArray();
        var expected = array.OrderBy(x => x).ToArray();

        algorithm.Sort(array);

        Assert.Equal(expected, array);
    }

    [Theory]
    [MemberData(nameof(AllAlgorithms))]
    public void Sort_PreservesAllElements(ISortAlgorithm algorithm)
    {
        var array = new[] { 5, 3, 8, 1, 9, 2, 7, 4, 6 };
        var expectedSorted = array.OrderBy(x => x).ToArray();

        algorithm.Sort(array);

        Assert.Equal(expectedSorted, array);
    }
}
