using LeetCodeRunner.Managers.HubManager;

namespace LeetCodeRunner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IHubManager hubManager = new HubManager();
            hubManager.ExecuteHub();
        }
        
    }
}