using System.Diagnostics;

namespace SimpleLibraryProject.Threads
{
    public class ThreadStarter
    {
        public static async Task RunAction(ThreadBuilder builder)
        {
            ThreadStart ts = new(() => builder.action());
            Thread thread = new Thread(ts);
            thread.Start();
        }

        public static async Task RunRawAction(Action action)
        {
            ThreadStart ts = new(() => action());
            Thread thread = new Thread(ts);
            thread.Start();
        }
        
        public static async Task DistributedActions(DistributedThreadBuilder builder)
        {
            foreach (Action action in builder.Actions)
            {
                await RunRawAction(action);
            }
        }
    }
}