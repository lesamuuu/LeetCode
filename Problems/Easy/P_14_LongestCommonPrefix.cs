namespace LeetCodeRunner.Problems.Easy
{
    public class P_14_LongestCommonPrefix
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            string res = "";

            if (strs[0].Length <= 0) return "";

            char actualChar = strs[0][0];

            int index = 0;

            bool exit = false;

            while (!exit)
            {
                foreach(string word in strs)
                {
                    if (word.Length <= index) return res;

                    if (!word[index].Equals(actualChar)) return res;

                }
                res += actualChar;

                if (strs[0].Length <= index + 1) return res;
                actualChar = strs[0][++index];
            }
            return res;
        }
    }
}