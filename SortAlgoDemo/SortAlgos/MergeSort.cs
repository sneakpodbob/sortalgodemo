using SortAlgoDemo.SortAlgos.Interface;

namespace SortAlgoDemo.SortAlgos;

public class MergeSort : ISortAlgorithm
{
    public string Name => "MergeSort";

    public void Sort(int[] array)
    {
        if (array.Length <= 1)
            return;

        MergeSortInternal(array, 0, array.Length - 1);
    }

    private static void MergeSortInternal(int[] array, int left, int right)
    {
        if (left >= right) return;

        var mid = left + (right - left) / 2;
        MergeSortInternal(array, left, mid);
        MergeSortInternal(array, mid + 1, right);
        Merge(array, left, mid, right);
    }

    private static void Merge(int[] array, int left, int mid, int right)
    {
        var leftLen = mid - left + 1;
        var rightLen = right - mid;

        var leftArr = new int[leftLen];
        var rightArr = new int[rightLen];

        Array.Copy(array, left, leftArr, 0, leftLen);
        Array.Copy(array, mid + 1, rightArr, 0, rightLen);

        int i = 0, j = 0, k = left;

        while (i < leftLen && j < rightLen)
        {
            if (leftArr[i] <= rightArr[j])
                array[k++] = leftArr[i++];
            else
                array[k++] = rightArr[j++];
        }

        while (i < leftLen)
            array[k++] = leftArr[i++];

        while (j < rightLen)
            array[k++] = rightArr[j++];
    }
}
