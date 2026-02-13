using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class LinqSort : ISortAlgorithm
{
    public string Name => "LinqSort";

    public void Sort(int[] array)
    {
        var n = array.Length;
        var list = new List<int>(array);
        list.Sort();
        list.CopyTo(array);
    }
}
