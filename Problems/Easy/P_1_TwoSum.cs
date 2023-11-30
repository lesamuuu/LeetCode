using System.Collections;

namespace LeetCodeRunner.Problems.Easy
{
    public class P_1_TwoSum
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            Hashtable hashtable = new Hashtable();

            int index = 0;

            int[] result = new int[2];

            foreach (int num in nums)
            {
                if (hashtable.ContainsKey(target-num)){
                    result = new int[] { index, (int)hashtable[target-num] };
                }
                else if (!hashtable.ContainsKey(num))
                {
                    hashtable.Add(num, index);
                }
                index += 1;
            }
            return result;
        }
    }
}