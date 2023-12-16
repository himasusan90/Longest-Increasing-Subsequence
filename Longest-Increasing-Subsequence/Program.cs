using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
        Console.WriteLine("Length of the longest increasing subarray is " + RecursiveLongestIncreasingSubsequence(arr, arr.Length));


    }
   


    static int RecursiveLongestIncreasingSubsequence(int[] arr, int n)
    {
        //basecase
        if(n==1)
        {
            return 1;
        }
        int res,currentSubarrayMax=1, maxLength = 1;
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
                maxLength = Math.Max(currentSubarrayMax,maxLength);
            
        return maxLength;

    }

}