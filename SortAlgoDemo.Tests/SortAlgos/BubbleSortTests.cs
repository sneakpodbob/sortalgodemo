using SortAlgoDemo.SortAlgos;

namespace SortAlgoDemo.Tests.SortAlgos;


/// <summary>
/// Unit tests for the <see cref="BubbleSort"/> class.
/// </summary>
public class BubbleSortTests
{
    /// <summary>
    /// Tests that the Name property returns the expected value "BubbleSort".
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsBubbleSort()
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        var name = bubbleSort.Name;

        // Assert
        Assert.Equal("BubbleSort", name);
    }

    /// <summary>
    /// Tests that the Name property never returns null.
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsNonNullValue()
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        var name = bubbleSort.Name;

        // Assert
        Assert.NotNull(name);
    }

    /// <summary>
    /// Tests that the Name property never returns an empty string.
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsNonEmptyValue()
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        var name = bubbleSort.Name;

        // Assert
        Assert.NotEmpty(name);
    }

    /// <summary>
    /// Tests that the Name property returns consistent values across multiple accesses.
    /// </summary>
    [Fact]
    public void Name_WhenAccessedMultipleTimes_ReturnsConsistentValue()
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        var name1 = bubbleSort.Name;
        var name2 = bubbleSort.Name;
        var name3 = bubbleSort.Name;

        // Assert
        Assert.Equal(name1, name2);
        Assert.Equal(name2, name3);
    }

    /// <summary>
    /// Tests that the Sort method throws NullReferenceException when the input array is null.
    /// </summary>
    [Fact]
    public void Sort_NullArray_ThrowsNullReferenceException()
    {
        // Arrange
        var bubbleSort = new BubbleSort();
        int[]? array = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => bubbleSort.Sort(array!));
    }

    /// <summary>
    /// Tests that the Sort method correctly handles an empty array without throwing exceptions.
    /// </summary>
    [Fact]
    public void Sort_EmptyArray_RemainsEmpty()
    {
        // Arrange
        var bubbleSort = new BubbleSort();
        var array = Array.Empty<int>();
        var expected = Array.Empty<int>();

        // Act
        bubbleSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that the Sort method correctly handles a single-element array without modification.
    /// </summary>
    [Fact]
    public void Sort_SingleElement_RemainsUnchanged()
    {
        // Arrange
        var bubbleSort = new BubbleSort();
        int[] array = [42];
        int[] expected = [42];

        // Act
        bubbleSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that the Sort method correctly sorts various input arrays with different characteristics.
    /// Parameterized test covering: already sorted, reverse sorted, duplicates, negatives, boundary values, etc.
    /// </summary>
    /// <param name="input">The input array to sort.</param>
    /// <param name="expected">The expected sorted array.</param>
    [Theory]
    [MemberData(nameof(SortTestData))]
    public void Sort_VariousInputs_SortsCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        bubbleSort.Sort(input);

        // Assert
        Assert.Equal(expected, input);
    }

    public static TheoryData<int[], int[]> SortTestData()
    {
        return new TheoryData<int[], int[]>
        {
            // Two elements - unsorted
            { [2, 1], [1, 2] },
            
            // Two elements - already sorted
            { [1, 2], [1, 2] },
            
            // Two elements - equal
            { [5, 5], [5, 5] },
            
            // Already sorted array
            { [1, 2, 3, 4, 5], [1, 2, 3, 4, 5] },
            
            // Reverse sorted array
            { [5, 4, 3, 2, 1], [1, 2, 3, 4, 5] },
            
            // Unsorted array
            { [3, 1, 4, 1, 5, 9, 2, 6], [1, 1, 2, 3, 4, 5, 6, 9] },
            
            // Array with duplicates
            { [4, 2, 4, 2, 1, 3, 1], [1, 1, 2, 2, 3, 4, 4] },
            
            // All same elements
            { [7, 7, 7, 7, 7], [7, 7, 7, 7, 7] },
            
            // Array with negative numbers
            { [-5, -1, -3, -2, -4], [-5, -4, -3, -2, -1] },
            
            // Array with mixed positive and negative
            { [3, -1, 0, -5, 2, -3], [-5, -3, -1, 0, 2, 3] },
            
            // Array with zero
            { [5, 0, -5], [-5, 0, 5] },
            
            // Array with int.MinValue and int.MaxValue
            { [int.MaxValue, 0, int.MinValue, 1, -1], [int.MinValue, -1, 0, 1, int.MaxValue] },
            
            // Array with only int.MinValue and int.MaxValue
            { [int.MaxValue, int.MinValue], [int.MinValue, int.MaxValue] },
            
            // Larger array
            { [10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
            
            // Array with consecutive duplicates
            { [3, 3, 1, 1, 2, 2], [1, 1, 2, 2, 3, 3] },
            
            // Three elements - various orders
            { [3, 2, 1], [1, 2, 3] },
            { [1, 3, 2], [1, 2, 3] },
            { [2, 1, 3], [1, 2, 3] }
        };
    }
}