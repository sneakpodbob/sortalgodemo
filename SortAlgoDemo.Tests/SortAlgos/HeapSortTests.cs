using SortAlgoDemo.SortAlgos;

namespace SortAlgoDemo.Tests.SortAlgos;


public class HeapSortTests
{
    /// <summary>
    /// Tests that Sort throws an exception when passed a null array.
    /// </summary>
    [Fact]
    public void Sort_NullArray_ThrowsNullReferenceException()
    {
        // Arrange
        var heapSort = new HeapSort();
        int[]? array = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => heapSort.Sort(array!));
    }

    /// <summary>
    /// Tests that Sort handles an empty array without throwing an exception.
    /// </summary>
    [Fact]
    public void Sort_EmptyArray_DoesNotThrow()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = Array.Empty<int>();

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Empty(array);
    }

    /// <summary>
    /// Tests that Sort handles a single element array correctly.
    /// </summary>
    [Fact]
    public void Sort_SingleElementArray_RemainsUnchanged()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 42 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Single(array);
        Assert.Equal(42, array[0]);
    }

    /// <summary>
    /// Tests that Sort correctly sorts a two-element array.
    /// </summary>
    /// <param name="first">The first element.</param>
    /// <param name="second">The second element.</param>
    /// <param name="expectedFirst">The expected first element after sorting.</param>
    /// <param name="expectedSecond">The expected second element after sorting.</param>
    [Theory]
    [InlineData(1, 2, 1, 2)]
    [InlineData(2, 1, 1, 2)]
    [InlineData(5, 5, 5, 5)]
    [InlineData(-1, -2, -2, -1)]
    [InlineData(int.MaxValue, int.MinValue, int.MinValue, int.MaxValue)]
    public void Sort_TwoElementArray_SortsCorrectly(int first, int second, int expectedFirst, int expectedSecond)
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { first, second };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(2, array.Length);
        Assert.Equal(expectedFirst, array[0]);
        Assert.Equal(expectedSecond, array[1]);
    }

    /// <summary>
    /// Tests that Sort correctly handles an already sorted array.
    /// </summary>
    [Fact]
    public void Sort_AlreadySortedArray_RemainsSorted()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly sorts a reverse-sorted array.
    /// </summary>
    [Fact]
    public void Sort_ReverseSortedArray_SortsInAscendingOrder()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly handles arrays with duplicate elements.
    /// </summary>
    [Fact]
    public void Sort_ArrayWithDuplicates_SortsCorrectly()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 5, 2, 8, 2, 9, 1, 5, 5 };
        var expected = new[] { 1, 2, 2, 5, 5, 5, 8, 9 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly handles an array with all identical elements.
    /// </summary>
    [Fact]
    public void Sort_AllSameElements_RemainsUnchanged()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 7, 7, 7, 7, 7, 7, 7 };
        var expected = new[] { 7, 7, 7, 7, 7, 7, 7 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly handles arrays with negative numbers.
    /// </summary>
    [Fact]
    public void Sort_ArrayWithNegativeNumbers_SortsCorrectly()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { -5, 3, -1, 7, -10, 0, 2 };
        var expected = new[] { -10, -5, -1, 0, 2, 3, 7 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly handles arrays with int.MinValue and int.MaxValue.
    /// </summary>
    [Fact]
    public void Sort_ArrayWithMinMaxValues_SortsCorrectly()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { int.MaxValue, 0, int.MinValue, 100, -100 };
        var expected = new[] { int.MinValue, -100, 0, 100, int.MaxValue };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(expected, array);
    }

    /// <summary>
    /// Tests that Sort correctly sorts a random unsorted array.
    /// </summary>
    [Fact]
    public void Sort_RandomUnsortedArray_SortsInAscendingOrder()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 64, 34, 25, 12, 22, 11, 90, 88, 45, 50, 23, 36, 18, 77 };

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.True(IsArraySorted(array));
        Assert.Equal(14, array.Length);
    }

    /// <summary>
    /// Tests that Sort maintains all original elements after sorting (no elements lost or added).
    /// </summary>
    [Fact]
    public void Sort_RandomArray_MaintainsAllElements()
    {
        // Arrange
        var heapSort = new HeapSort();
        var array = new[] { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
        var originalElements = array.OrderBy(x => x).ToArray();

        // Act
        heapSort.Sort(array);

        // Assert
        Assert.Equal(originalElements, array);
    }

    /// <summary>
    /// Tests that Sort works correctly with a three-element array in various orders.
    /// </summary>
    /// <param name="input">The input array to sort.</param>
    /// <param name="expected">The expected sorted array.</param>
    [Theory]
    [MemberData(nameof(GetThreeElementTestCases))]
    public void Sort_ThreeElementArray_SortsCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var heapSort = new HeapSort();

        // Act
        heapSort.Sort(input);

        // Assert
        Assert.Equal(expected, input);
    }

    /// <summary>
    /// Tests that Sort works correctly with larger arrays of various patterns.
    /// </summary>
    /// <param name="input">The input array to sort.</param>
    [Theory]
    [MemberData(nameof(GetLargerArrayTestCases))]
    public void Sort_LargerArrays_SortsInAscendingOrder(int[] input)
    {
        // Arrange
        var heapSort = new HeapSort();
        var expectedLength = input.Length;

        // Act
        heapSort.Sort(input);

        // Assert
        Assert.True(IsArraySorted(input));
        Assert.Equal(expectedLength, input.Length);
    }

    /// <summary>
    /// Provides test data for three-element array sorting tests.
    /// </summary>
    public static TheoryData<int[], int[]> GetThreeElementTestCases()
    {
        return new TheoryData<int[], int[]>
        {
            { new[] { 1, 2, 3 }, new[] { 1, 2, 3 } },
            { new[] { 3, 2, 1 }, new[] { 1, 2, 3 } },
            { new[] { 2, 1, 3 }, new[] { 1, 2, 3 } },
            { new[] { 2, 3, 1 }, new[] { 1, 2, 3 } },
            { new[] { 1, 3, 2 }, new[] { 1, 2, 3 } },
            { new[] { 3, 1, 2 }, new[] { 1, 2, 3 } },
            { new[] { 5, 5, 5 }, new[] { 5, 5, 5 } }
        };
    }

    /// <summary>
    /// Provides test data for larger array sorting tests.
    /// </summary>
    public static TheoryData<int[]> GetLargerArrayTestCases()
    {
        return new TheoryData<int[]>
        {
            new[] { 4, 10, 3, 5, 1 },
            new[] { 100, 50, 25, 75, 10, 90, 30, 60 },
            new[] { -50, -10, -100, -25, -75 },
            new[] { 0, 0, 0, 1, 1, 1, -1, -1, -1 },
            new[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
            new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 }
        };
    }

    /// <summary>
    /// Helper method to verify if an array is sorted in ascending order.
    /// </summary>
    /// <param name="array">The array to check.</param>
    /// <returns>True if the array is sorted in ascending order; otherwise, false.</returns>
    private static bool IsArraySorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Tests that the Name property returns the expected algorithm name "HeapSort".
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsHeapSort()
    {
        // Arrange
        var heapSort = new HeapSort();

        // Act
        var result = heapSort.Name;

        // Assert
        Assert.Equal("HeapSort", result);
    }

    /// <summary>
    /// Tests that the Name property returns a non-null value.
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsNonNullValue()
    {
        // Arrange
        var heapSort = new HeapSort();

        // Act
        var result = heapSort.Name;

        // Assert
        Assert.NotNull(result);
    }

    /// <summary>
    /// Tests that the Name property returns a non-empty string.
    /// </summary>
    [Fact]
    public void Name_WhenAccessed_ReturnsNonEmptyString()
    {
        // Arrange
        var heapSort = new HeapSort();

        // Act
        var result = heapSort.Name;

        // Assert
        Assert.NotEmpty(result);
    }

    /// <summary>
    /// Tests that the Name property returns a consistent value across multiple accesses.
    /// </summary>
    [Fact]
    public void Name_WhenAccessedMultipleTimes_ReturnsSameValue()
    {
        // Arrange
        var heapSort = new HeapSort();

        // Act
        var result1 = heapSort.Name;
        var result2 = heapSort.Name;

        // Assert
        Assert.Equal(result1, result2);
    }
}