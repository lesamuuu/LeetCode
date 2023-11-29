using System;
using System.Collections;

namespace LeetCodeRunner.ExercisesHub.UserInterfaceManager
{
    public class UserInterfaceManager : IUserInterfaceManager
    {
        public void ShowDialog(string dialog)
        {
            Console.WriteLine(dialog);
        }

        public int RequestForInt(string dialog)
        {
            ShowDialog(dialog);

            while (true)
            {
                string givenValue = Console.ReadLine();
            
                string messageError = "";
                if (int.TryParse(givenValue, out int validNumber))
                {
                    return validNumber;
                }
                ShowDialog("Invalid input. Please enter an integer");
            }
        }

        public int RequestForIntKeyMatcher(string dialog, Hashtable hashtable)
        {
            ShowDialog(dialog);

            while (true)
            {
                string givenValue = Console.ReadLine();
            
                string messageError = "";
                if (int.TryParse(givenValue, out int validNumber))
                {
                    if(hashtable.ContainsKey(validNumber)) return validNumber;
                    ShowDialog($"The introduced value: {validNumber} is not valid in this context");
                }
                ShowDialog("Invalid input. Please enter an integer");
            }
        }
    }
}