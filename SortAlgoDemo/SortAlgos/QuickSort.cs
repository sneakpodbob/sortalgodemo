using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class QuickSort : ISortAlgorithm
{
    public string Name => "QuickSort";

    public void Sort(int[] array)
    {
        QuickSortInternal(array, 0, array.Length - 1);
    }

    private static void QuickSortInternal(int[] array, int low, int high)
    {
        while (true)
        {
            if (low >= high) return;
            var pivotIndex = Partition(array, low, high);
            QuickSortInternal(array, low, pivotIndex - 1);
            low = pivotIndex + 1;
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        var pivot = array[high];
        var i = low - 1;

        for (var j = low; j < high; j++)
        {
            if (array[j] > pivot) continue;

            i++;
            (array[i], array[j]) = (array[j], array[i]);
        }

        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return i + 1;
    }
}
