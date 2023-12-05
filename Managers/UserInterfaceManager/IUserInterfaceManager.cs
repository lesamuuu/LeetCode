using System;
using System.Collections.Generic;

namespace LeetCodeRunner.Managers.UserInterfaceManager
{
    public interface IUserInterfaceManager
    {
        void ShowDialog(string dialog);
        
        // Requests for single DataType
        int RequestForInt(string dialog);
        bool RequestForBool(string dialog);
        
        // Special requests
        int RequestForIntKeyMatcher(string dialog, Dictionary<int, string> hashtable);
        IEnumerable<object> RequestParameters(IEnumerable<KeyValuePair<string, Type>> parametersRequested);
        
        // Arrays
        int[] RequestForIntArray(string dialog);
        string[] RequestForStringArray(string dialog);

    }
}