namespace LeetCodeRunner.Problems
{
    public class P_28_FindTheIndexOfTheFistOccurenceInAString
    {
        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Contains(needle))
            {
                return haystack.IndexOf(needle);
            }
            return -1;
        }
    }
}