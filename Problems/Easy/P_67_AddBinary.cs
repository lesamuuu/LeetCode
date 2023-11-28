using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeRunner.Problems
{
    public class P_67_AddBinary
    {
        public static string AddBinary(string a, string b)
        {
            int tenth = 0;

            int maxLength, minLength, lengthDiff;

            maxLength = a.Length < b.Length ? b.Length : a.Length;
            minLength = a.Length > b.Length ? b.Length : a.Length;

            int aIndex = a.Length - 1, bIndex = b.Length - 1;

            lengthDiff = Math.Abs(a.Length - b.Length);

            int[] aNumbersArray = a.Select(x => x - '0').ToArray();
            int[] bNumbersArray = b.Select(x => x - '0').ToArray();

            int[] biggerArray = new int[maxLength];
            biggerArray = aNumbersArray.Length == maxLength ? aNumbersArray : bNumbersArray;

            List<int> resultNumberList = new List<int>();


            int localRes;
            string result = "";

            // Sums the number in range of smaller number
            for (int i = 0; i < minLength; i++)
            {
                // Sum of the two last numbers
                localRes = aNumbersArray[aIndex--] + bNumbersArray[bIndex--] + tenth;

                // If sum overflows, save it in tenth 
                tenth = localRes >= 2 ? 1 : 0;

                // If tenth is 1, reset localRes to 0. If not, leave it 
                localRes = localRes % 2 == 0 ? 0 : 1;

                // Add the result to the list (result is backwards)
                resultNumberList.Add(localRes);
            }

            // Add the rest of the bigger number (in case one number is bigger), taking in account tenth
            for(int i = lengthDiff - 1; i >= 0; i--)
            {
                localRes = biggerArray[i] + tenth;

                // If sum overflows, save it in tenth 
                tenth = localRes >= 2 ? 1 : 0;

                // If tenth is 1, reset localRes to 0. If not, leave it 
                localRes = localRes % 2 == 0 ? 0 : 1;

                // Add the result to the list (result is backwards)
                resultNumberList.Add(localRes);
            }

            if (tenth == 1)
            {
                resultNumberList.Add(1);
            }

            for (int i = resultNumberList.Count - 1; i >= 0; i--)
            {
                result += resultNumberList[i];
            }

            return result;
        }
    }
}