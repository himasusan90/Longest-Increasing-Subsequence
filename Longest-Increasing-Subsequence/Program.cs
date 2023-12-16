using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
        Console.WriteLine("Length of the longest increasing subarray is " + RecursiveLongestIncreasingSubsequence(arr, arr.Length));
        Console.WriteLine("Length of the longest increasing subarray is " + DPLongestIncreasingSubsequence(arr));

    }



    static int RecursiveLongestIncreasingSubsequence(int[] arr, int n)
    {
        //basecase
        if (n == 1)
        {
            return 1;
        }
        int res, currentSubarrayMax = 1, maxLength = 1;
        //recursive only until n-2, not including the last element. incliuding the last element 
        //results in the same initial elements in the array. So we find the longest subarray ending at n-2
        //and check if adding the last element to it would increase its maximum length by 1.
        for (int i = 1; i < n; i++)
        {
            res = RecursiveLongestIncreasingSubsequence(arr, i);
            if (arr[i - 1] < arr[n - 1] && currentSubarrayMax < res + 1)
            {
                currentSubarrayMax = res + 1;
            }
        }
        maxLength = Math.Max(currentSubarrayMax, maxLength);

        return maxLength;

    }

    static int DPLongestIncreasingSubsequence(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return 0;
        }
        int[] dparr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            dparr[i] = 1;
        }

        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                //lis{i]<lis[j]+1 because an already increasing subsequence has been found.
                if (arr[i] > arr[j] && dparr[i] < dparr[j] + 1)
                {
                    dparr[i] = dparr[j] + 1;
                }
            }
        }
        int max = 0;
        for (int k = 0; k < arr.Length; k++)
        {
            if (dparr[k] > max)
            {
                max = dparr[k];
            }
        }
        return max;
    }
}