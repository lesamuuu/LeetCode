using System.Linq;

namespace LeetCodeRunner.Problems
{
    public class P_35_SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            if (nums.Contains(target))
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == target) return i;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > target) return i;
            }

            return nums.Length;
        }
    }
}