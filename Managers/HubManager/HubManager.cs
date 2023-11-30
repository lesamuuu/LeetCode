using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using LeetCodeRunner.ExercisesHub;
using LeetCodeRunner.ExercisesHub.StringExtensions;
using LeetCodeRunner.ExercisesHub.UserInterfaceManager;

namespace LeetCodeRunner.Managers.HubManager
{
    public class HubManager : IHubManager
    {
        private IUserInterfaceManager _IUserInterfaceManager = new UserInterfaceManager();

        /* HashTable used to relate exercises numbers to the corresponding files
        Example: For the file P_1_TwoSum, the tuple will be >> 1 - P_1_TwoSum */
        private Hashtable _exercisesNumAndFile = new Hashtable();
        
        /* HashTable used to get the parameters of a method
        Parameter Name - Parameter Type */
        private Hashtable _parametersRequested = new Hashtable();
        
        public void ExecuteHub()
        {
            // TODO: Change default EasyFolder (absolute to relative path) depending on the user choice
            _exercisesNumAndFile = HubKeys.Paths.EasyFolder.GetHashedExercisesList();
            
            string askForExerciseNumberComplete = $"{GetSortedExercisesList(_exercisesNumAndFile)}\n{HubKeys.Dialogs.AskForExerciseNumber}";
            
            // Ask for the number of the exercise
            int exerciseNumber = _IUserInterfaceManager.RequestForIntKeyMatcher(askForExerciseNumberComplete, _exercisesNumAndFile);
            
            // Gets the MethodInfo of the class
            // TODO: Change default EasyPath depending on the user choice
            MethodInfo[] classMethodsInfo = GetMethodsInfo($"{HubKeys.Paths.EasyPath}{_exercisesNumAndFile[exerciseNumber]}");
            
            // Get parameters HashTable
            _parametersRequested = GetParameters(classMethodsInfo[0]);
        }
        
        private MethodInfo[] GetMethodsInfo(string className)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly.GetType(className);

            MethodInfo[] methodsInfo = classType.GetMethods();

            return methodsInfo;
        }
        
        public Hashtable GetParameters(MethodInfo methodInfo)
        {
            Hashtable parametersNameAndType = new Hashtable();
            
            ParameterInfo[] parametersInfo = methodInfo.GetParameters();

            foreach (ParameterInfo parameterInfo in parametersInfo)
            {
                parametersNameAndType.Add(parameterInfo.Name, parameterInfo.ParameterType);
            }

            return parametersNameAndType;
        }
        
        public string GetSortedExercisesList(Hashtable exercisesNumAndFile)
        {
            string sortedExercisesList ="";
            var sortedEntries = exercisesNumAndFile.Cast<DictionaryEntry>().OrderBy(entry => entry.Key);
            foreach (DictionaryEntry sortedKey in sortedEntries)
            {
                sortedExercisesList += $"{FormatExerciseStringListed(sortedKey)}\n";
            }

            return sortedExercisesList;
        }

        public string FormatExerciseStringListed(DictionaryEntry exerciseNumAndFile)
        {
            string spaceAfterNumber = "";
            
            switch (exerciseNumAndFile.Key.ToString().Length)
            {
                case 1:
                    spaceAfterNumber = "  ";
                    break;
                case 2:
                    spaceAfterNumber = " ";
                    break;
                case 3:
                    spaceAfterNumber = "";
                    break;
            }

            return $"[{exerciseNumAndFile.Key}{spaceAfterNumber}] --> {exerciseNumAndFile.Value}";
        }
    }
}