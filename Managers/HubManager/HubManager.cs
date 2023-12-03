using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LeetCodeRunner.ExercisesHub;
using LeetCodeRunner.ExercisesHub.StringExtensions;
using LeetCodeRunner.Managers.UserInterfaceManager;

namespace LeetCodeRunner.Managers.HubManager
{
    public class HubManager : IHubManager
    {
        private IUserInterfaceManager _IUserInterfaceManager = new UserInterfaceManager.UserInterfaceManager();

        /* Dictionary used to relate exercises numbers to the corresponding files
        Example: For the file P_1_TwoSum, the tuple will be >> 1 - P_1_TwoSum */
        private Dictionary<int, string> _exercisesNumAndFile = new Dictionary<int, string>();
        
        /* Dictionary used to get the parameters of a method
        Parameter Name - Parameter Type */
        private List<KeyValuePair<string, Type>> _parametersRequested = new List<KeyValuePair<string, Type>>();

        /* List of introduced parameters */
        private IEnumerable<object> _parametersIntroduced = new List<object>();

        /* Result of the invoked method */
        private object _invokedResult;
        
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
            
            // Request parameters
            _parametersIntroduced = _IUserInterfaceManager.RequestParameters(_parametersRequested);

            // Result of the execution 
            _invokedResult = InvokeMethod(classMethodsInfo[0], _parametersIntroduced);

            // Show result to the user
            _IUserInterfaceManager.ShowDialog($"{HubKeys.Dialogs.ResultIs}{_invokedResult}");
            
            // Execute again if needed
            if (_IUserInterfaceManager.RequestForBool($"{HubKeys.Dialogs.AskIfExecuteAgain} {HubKeys.Dialogs.YesOrNo}"))
            {
                ExecuteHub();
            };
        }
        
        private MethodInfo[] GetMethodsInfo(string className)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly.GetType(className);

            MethodInfo[] methodsInfo = classType.GetMethods();

            return methodsInfo;
        }
        
        private List<KeyValuePair<string, Type>> GetParameters(MethodInfo methodInfo)
        {
            List<KeyValuePair<string, Type>> parametersNameAndTypeList = new List<KeyValuePair<string, Type>>();
            
            ParameterInfo[] parametersInfo = methodInfo.GetParameters();

            foreach (ParameterInfo parameterInfo in parametersInfo)
            {
                parametersNameAndTypeList.Add(new KeyValuePair<string, Type>(parameterInfo.Name, parameterInfo.ParameterType));
            }

            return parametersNameAndTypeList;
        }
        
        private string GetSortedExercisesList(Dictionary<int, string> exercisesNumAndFile)
        {
            string sortedExercisesList ="";
            var sortedEntries = exercisesNumAndFile.OrderBy(entry => entry.Key);
            
            foreach (KeyValuePair<int, string> sortedKey in sortedEntries)
            {
                sortedExercisesList += $"{FormatExerciseStringListed(sortedKey)}\n";
            }

            return sortedExercisesList;
        }

        private string FormatExerciseStringListed(KeyValuePair<int, string> exerciseNumAndFile)
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

        private object InvokeMethod(MethodInfo method, IEnumerable<object> parameters)
        {
            object[] parametersArray = parameters.ToArray();
            object invokedResult = null;

            try
            {
                invokedResult = method.Invoke(null, parametersArray);
            }
            catch (TargetInvocationException e)
            {
                _IUserInterfaceManager.ShowDialog($"Exception during method invocation: {e.InnerException.Message}");
            }

            return invokedResult;
        }
    }
}