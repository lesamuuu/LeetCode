using System.Collections.Generic;

namespace LeetCodeRunner.Problems
{
    public class P_26_RemoveDuplicatesFromSortedArray
    {
        public static int RemoveDuplicates(int[] nums)
        {
            int current = nums[0];
            List<int> sortedNums = new List<int>();


            sortedNums.Add(current);
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > current)
                {
                    sortedNums.Add(nums[i]);
                    current = nums[i];
                }
            }

            for(int i = 0; i < sortedNums.Count; i++)
            {
                nums[i] = sortedNums[i];
            }

            return sortedNums.Count;
        }
    }
}