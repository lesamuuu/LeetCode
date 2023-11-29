using System.Collections;

namespace LeetCodeRunner.ExercisesHub.UserInterfaceManager
{
    public interface IUserInterfaceManager
    {
        void ShowDialog(string dialog);
        int RequestForInt(string dialog);
        int RequestForIntKeyMatcher(string dialog, Hashtable hashtable);
        
        
    }
}