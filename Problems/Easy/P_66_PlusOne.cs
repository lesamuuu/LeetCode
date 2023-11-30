using System;

namespace LeetCodeRunner.Problems.Easy
{
    public class P_66_PlusOne
    {
        public static int[] PlusOne(int[] digits)
        {
            int tenth = 0;

            digits[digits.Length - 1] += 1;


            for (int i = digits.Length-1; i >= 0; i--)
            {
                if (tenth == 1)
                {
                    digits[i] += tenth;
                    tenth = 0;
                }

                if (digits[i] >= 10) 
                {
                    digits[i] = 0;
                    tenth = 1;

                    if (i == 0)
                    {
                        int[] digitAux = new int[digits.Length + 1];
                        digitAux[0] = tenth;
                        Array.Copy(digits, 0, digitAux, 1, digits.Length);
                        digits = digitAux;
                    }
                }
                else
                {
                    tenth = 0;
                }
            }

            return digits;
        }
    }
}