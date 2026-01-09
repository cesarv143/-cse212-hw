using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' 
    /// followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1) Create an array of size 'length'.
        // 2) Loop from i = 0 to length - 1.
        // 3) At each index, store number * (i + 1).
        // 4) Return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 
    /// then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list 
    /// rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1) Normalize amount: amount = amount % data.Count (safe if amount == data.Count).
        // 2) Get the tail slice: last 'amount' elements.
        // 3) Get the head slice: the rest of the elements.
        // 4) Clear the original list.
        // 5) Add tail first, then head back into the list.

        if (data == null || data.Count == 0) return;

        amount = amount % data.Count;
        if (amount == 0) return;

        List<int> tail = data.GetRange(data.Count - amount, amount);
        List<int> head = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}