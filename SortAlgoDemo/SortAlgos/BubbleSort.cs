using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class BubbleSort : ISortAlgorithm
{
    public string Name => "BubbleSort";

    public void Sort(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var swapped = false;
            for (var j = 0; j < n - i - 1; j++)
            {
                if (array[j] <= array[j + 1]) continue;

                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                swapped = true;
            }
            if (!swapped)
                break;
        }
    }
}
