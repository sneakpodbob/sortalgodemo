using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class HeapSort : ISortAlgorithm
{
    public string Name => "HeapSort";

    public void Sort(int[] array)
    {
        var n = array.Length;

        for (var i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        for (var i = n - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        while (true)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && array[left] > array[largest]) largest = left;

            if (right < n && array[right] > array[largest]) largest = right;

            if (largest == i) return;

            (array[i], array[largest]) = (array[largest], array[i]);
            i = largest;
        }
    }
}
