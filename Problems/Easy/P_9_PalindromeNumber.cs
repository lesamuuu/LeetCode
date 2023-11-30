namespace LeetCodeRunner.Problems.Easy
{
    public class P_9_PalindromeNumber
    {
        public static bool IsPalindrome(int x)
        {
            string numberString = x.ToString();

            if (!numberString[0].Equals(numberString[numberString.Length-1])) return false;    

            if (numberString.Length <= 1)return true;


            numberString = numberString.Substring(1, numberString.Length - 2);

            if (numberString.Length == 0) return true;

            return IsPalindrome(int.Parse(numberString));
        }
    }
}