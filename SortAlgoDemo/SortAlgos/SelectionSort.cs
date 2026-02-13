using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class SelectionSort : ISortAlgorithm
{
    public string Name => "SelectionSort";

    public void Sort(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }
}
