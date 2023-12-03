using System;
using System.Collections.Generic;
using LeetCodeRunner.ExercisesHub;

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
                var introducedParameter = RequestObject($"Insert value for {parameter.Key}, (Type: {parameter.Value})", parameter.Value); 
                introducedParameters.Add(introducedParameter);
            }

            return introducedParameters;
        }
    }
}