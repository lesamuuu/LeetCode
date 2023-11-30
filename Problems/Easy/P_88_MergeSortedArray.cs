using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeRunner.Problems.Easy
{
    public class P_88_MergeSortedArray
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            List <int> ResList = new List <int>();

            int validNumbers = m + n;
            int index1 = 0;
            int index2 = 0;

            // No valus in array2
            if (n == 0) return;

            // No values in array1, answer is array2 on array1
            if (m == 0) 
            { 
                //nums1  = nums2; doesn t work somehow
                // Doing a loop instead
                for (int i = 0; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[i];
                }
                return; 
            } 


            while (index1 < validNumbers && index2 < n)
            {
                if (index1 < m && nums1[index1] < nums2[index2])
                {
                    ResList.Add(nums1[index1]);
                    index1++;
                }
                else if (nums1[index1] == 0 && index1 >= m)
                {
                    ResList.Add(nums2[index2]);
                    index2++;
                }
                else
                {
                    ResList.Add(nums2[index2]);
                    index2++;
                }
            }

            // If there is any value left
            if(index1 < m) ResList.AddRange(nums1.Skip(index1));
            else if (index2 < n) ResList.AddRange(nums2.Skip(index2));

            // This doesn t work for LeetCode somewhy
            // nums1 = ResList.ToArray();
            
            // Using a simple loop instead
            for (int i = 0; i < nums1.Length; i++)
            {
                nums1[i] = ResList[i];
            }

            string arrayjoi = string.Join(",", nums1);

            Console.WriteLine(arrayjoi);
        }
    }
}