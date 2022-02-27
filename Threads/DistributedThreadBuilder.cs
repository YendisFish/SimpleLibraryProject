namespace SimpleLibraryProject.Threads
{
    public class DistributedThreadBuilder
    {
        public List<Action> Actions { get; set; }

        public DistributedThreadBuilder(List<Action> actions)
        {
            this.Actions = actions;
        }

        public async Task InsertAction(Action action)
        {
            this.Actions.Add(action);
        }
    }
}