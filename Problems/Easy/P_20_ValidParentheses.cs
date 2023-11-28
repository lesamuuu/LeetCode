using System.Collections.Generic;

namespace LeetCodeRunner.Problems
{
    public class P_20_ValidParentheses
    {
        public static bool IsValid(string s)
        {

            Stack<char> stack = new Stack<char>();

            foreach (char c in s) 
            { 
     

                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':

                        stack.Push(c);
                        break;

                    case ')':
                        if (stack.Count == 0 || !stack.Pop().Equals('(')) return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || !stack.Pop().Equals('[')) return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || !stack.Pop().Equals('{')) return false;
                        break;
                }

            }
            if (stack.Count == 0) return true;
            else return false; 
        }
    }
}