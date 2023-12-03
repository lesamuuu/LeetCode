using System;
using System.Collections.Generic;

namespace LeetCodeRunner.Managers.UserInterfaceManager
{
    public interface IUserInterfaceManager
    {
        void ShowDialog(string dialog);
        int RequestForInt(string dialog);
        bool RequestForBool(string dialog);
        int RequestForIntKeyMatcher(string dialog, Dictionary<int, string> hashtable);
        IEnumerable<object> RequestParameters(IEnumerable<KeyValuePair<string, Type>> parametersRequested);

    }
}