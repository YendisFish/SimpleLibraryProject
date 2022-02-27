namespace SimpleLibraryProject.Threads
{
    public class ThreadBuilder
    {
        public Action action { get; set; }

        public ThreadBuilder(Action action)
        {
            this.action = action;
        }
    }
}