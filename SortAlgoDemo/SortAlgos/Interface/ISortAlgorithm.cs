namespace SortAlgoDemo.SortAlgos.Interface;

public interface ISortAlgorithm
{
    string Name { get; }
    void Sort(int[] array);
}
