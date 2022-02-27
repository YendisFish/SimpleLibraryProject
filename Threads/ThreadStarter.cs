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
    }
}