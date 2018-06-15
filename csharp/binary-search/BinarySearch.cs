using System;

public class BinarySearch
{
    private int[] array;

    public BinarySearch(int[] input)
    {
        array = input;
        Array.Sort(array);
    }

    public int Find(int value)
    {
        int start = 0;
        int end = array.Length - 1;
        int index;

        if (array.Length == 0 || value < array[0] || value > array[end])
        {
            return -1;
        }

        while (start <= end)
        {
            index = (start + end) / 2;

            if (array[index] == value)
            {
                return index;
            }
            else if (array[index] > value)
            {
                end = index - 1;
            }
            else
            {
                start = index + 1;
            }
        }

        return -1;
    }
}