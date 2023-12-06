namespace LeetCodeRunner.ExercisesHub
{
    public static class HubKeys
    {
        public static class Paths
        {
            public const string ProblemsFolder = @"A:\Programas\JetBrains\RidersProjects\LeetCode\LeetCode\Problems";
            public const string EasyFolder = @"A:\Programas\JetBrains\RidersProjects\LeetCode\LeetCode\Problems\Easy";
            public const string MediumFolder = @"A:\Programas\JetBrains\RidersProjects\LeetCode\LeetCode\Problems\Medium";
            public const string HardFolder = @"A:\Programas\JetBrains\RidersProjects\LeetCode\LeetCode\Problems\Hard";

            // TODO: investigate a proper way to do this without being in bin/Debug
            // public static string ProblemsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Problems");
            // public static string EasyFolder = Path.Combine(ProblemsFolder, "Easy");
            // public static string MediumFolder = Path.Combine(ProblemsFolder, "Medium");
            // public static string HardFolder = Path.Combine(ProblemsFolder, "Hard");
            
            public const string ProblemsPath = "LeetCodeRunner.Problems.";
            public const string EasyPath = "LeetCodeRunner.Problems.Easy.";
            public const string MediumPath = "LeetCodeRunner.Problems.Medium.";
            public const string HardPath = "LeetCodeRunner.Problems.Hard.";
        }
        
        public static class Dialogs
        {
            public const string AskForExerciseNumber = "What exercise do you want to execute?";
            public const string AskIfExecuteAgain = "Do you want to execute another exercice?";
            public const string YesOrNo = "(Y/N)";
            public const string ResultIs = "The result is: ";
            public const string RequestIntArrayInstructions = "Current value is: [{0}]. Type your next number or: [C] to complete the array / [D] to delete last index.";
            public const string RequestStringArrayInstructions = "Current value is: [{0}]. Type your next string or: [@C] to complete the array / [@D] to delete last index.";
            public const string InsertValueForParameter = "Insert value for parameter [{0}], of Type [{1}]";
        }

        public static class Errors
        {
            public const string InvalidInputIntegerRequested = "Invalid input. Please enter an integer";
            public const string IntroducedValueNotValid = "The introduced value is not valid in this context: ";
            public const string InvalidInput = "Invalid input. Please enter a value of type: ";
            public const string ConversionNotSupported = "Conversion is not supported for type: ";
            public const string InvalidInputBoolRequested = "Invalid input, please enter 'Y' of 'YES' or 'N' for 'NO'";
            public const string CantDeleteEmptyArray = "You can't delete the last index since the array is empty";
        }
    }
}