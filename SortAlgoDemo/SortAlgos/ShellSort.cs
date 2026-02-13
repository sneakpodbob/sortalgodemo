using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class ShellSort : ISortAlgorithm
{
    public string Name => "ShellSort";

    public void Sort(int[] array)
    {
        var n = array.Length;

        for (var gap = n / 2; gap > 0; gap /= 2)
        {
            for (var i = gap; i < n; i++)
            {
                var temp = array[i];
                var j = i;
                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }
                array[j] = temp;
            }
        }
    }
}
