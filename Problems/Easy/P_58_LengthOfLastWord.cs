namespace LeetCodeRunner.Problems
{
    public class P_58_LengthOfLastWord
    {
        public static int LengthOfLastWord(string s)
        {
            string trimmed = s.Trim();
            int len = trimmed.LastIndexOf(" ");

            string lala = trimmed.Substring(len+1);

            return lala.Length;


            // Inline
            return s.Trim().Substring(s.Trim().LastIndexOf(" ")+1).Length;
        }
    }
}