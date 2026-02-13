using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class LinqSort : ISortAlgorithm
{
    public string Name => "LinqSort";

    public void Sort(int[] array)
    {
        Array.Sort(array);
    }
}
