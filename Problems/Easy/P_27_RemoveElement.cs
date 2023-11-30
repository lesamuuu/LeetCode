using System.Collections.Generic;

namespace LeetCodeRunner.Problems.Easy
{
    public class P_27_RemoveElement
    {
        public static int RemoveElement(int[] nums, int val)
        {
            List<int> sortedNums = new List<int>();


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    sortedNums.Add(nums[i]);
                }
            }

            for (int i = 0; i < sortedNums.Count; i++)
            {
                nums[i] = sortedNums[i];
            }

            return sortedNums.Count;
        }
    }
}