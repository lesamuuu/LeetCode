using System;
using System.Collections.Generic;
using LeetCodeRunner.ExercisesHub;
using LeetCodeRunner.ExternalClasses;

namespace LeetCodeRunner.Managers.UserInterfaceManager
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
                ShowDialog(HubKeys.Errors.InvalidInputIntegerRequested);
            }
        }

        public bool RequestForBool(string dialog)
        {
            ShowDialog(dialog);
            bool validBool = false;
            
            while (true)
            {
                string givenValue = Console.ReadLine();
            
                string messageError = "";
                switch (givenValue.ToUpper())
                {
                    case "Y":
                        validBool = true;
                        break;
                    case "N":
                        validBool = false;
                        break;
                    default:
                        messageError = HubKeys.Errors.InvalidInputBoolRequested;
                        break;
                }

                if (messageError != "") ShowDialog(messageError);
                else return validBool;
            }
        }

        public int RequestForIntKeyMatcher(string dialog, Dictionary<int, string> hashtable)
        {
            ShowDialog(dialog);

            while (true)
            {
                string givenValue = Console.ReadLine();
            
                string messageError = "";
                if (int.TryParse(givenValue, out int validNumber))
                {
                    if(hashtable.ContainsKey(validNumber)) return validNumber;
                    ShowDialog($"{HubKeys.Errors.IntroducedValueNotValid}{validNumber}");
                }
                ShowDialog(HubKeys.Errors.InvalidInputIntegerRequested);
            }
        }

        private object RequestObject(string dialog, Type requestedType)
        {
            ShowDialog(dialog);
            while (true)
            {
                string givenValue = Console.ReadLine();

                try
                {
                    object convertedValue = Convert.ChangeType(givenValue, requestedType);
                    return convertedValue;
                }
                catch (FormatException)
                {
                    ShowDialog($"{HubKeys.Errors.InvalidInput}{requestedType.Name}");
                }
                catch (InvalidCastException)
                {
                    ShowDialog($"{HubKeys.Errors.ConversionNotSupported}{requestedType.Name}");
                }
            }
        }

        public IEnumerable<object> RequestParameters(IEnumerable<KeyValuePair<string, Type>> requestedParameters)
        {
            var introducedParameters = new List<object>();
            foreach (var parameter in requestedParameters)
            {
                if (parameter.Value.IsArray)
                {
                    Type elementType = parameter.Value.GetElementType();
                    if (elementType == typeof(int))
                    {
                        var introducedIntArray = RequestForIntArray($"{HubKeys.Dialogs.InsertValueFor} {parameter.Key}, ({HubKeys.Generic.Type}: {parameter.Value})");
                        introducedParameters.Add(introducedIntArray);
                    }
                    else if (elementType == typeof(string))
                    {
                        // string array
                    }
                }
                else if (parameter.Value == typeof(ListNode))
                {
                    // ListNode
                }
                else
                {
                    var introducedParameter = RequestObject($"{HubKeys.Dialogs.InsertValueFor} {parameter.Key}, ({HubKeys.Generic.Type}: {parameter.Value})", parameter.Value); 
                    introducedParameters.Add(introducedParameter);
                }    
            }

            return introducedParameters;
        }

        public int[] RequestForIntArray(string dialog)
        {
            ShowDialog(dialog);

            List<int> insertedInt = new List<int>();
            
            while (true)
            {
                string givenValue = Console.ReadLine();
       
                if (int.TryParse(givenValue, out int validNumber))
                {
                    insertedInt.Add(validNumber);
                }
                else if (givenValue.ToUpper() == "D")
                {
                    if (insertedInt.Count > 0) insertedInt.RemoveAt(insertedInt.Count - 1);
                    else ShowDialog(HubKeys.Errors.CantDeleteEmptyArray);
                }
                else if (givenValue.ToUpper() == "C")
                {
                    return insertedInt.ToArray();
                }
                else
                { 
                    ShowDialog(HubKeys.Errors.InvalidInputIntegerRequested);
                }
                
                ShowDialog($"{HubKeys.Dialogs.CurrentValueIs}[{string.Join(",", insertedInt)}] {HubKeys.Dialogs.RequestIntArrayInstructions}");
            }
        }

        public string[] RequestForStringArray(string dialog)
        {
            throw new NotImplementedException();
        }
    }
}