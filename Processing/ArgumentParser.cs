namespace SimpleLibraryProject.Processing
{
    public class ArgumentParser
    {
        public Dictionary<string, Action> Functions = new();
        public string[] Args { get; set; }

        public ArgumentParser(string[] args)
        {
            Functions = new Dictionary<string, Action>();
            Args = args;
        }

        public async Task Insert(KeyValuePair<string, Action> val)
        {
            this.Functions.Add(val.Key, val.Value);
        }        
        
        public async Task Insert(string val, Action action)
        {
            this.Functions.Add(val, action);
        }

        public async Task Process()
        {
            foreach (string val in this.Args)
            {
                foreach (KeyValuePair<string, Action> func in this.Functions)
                {
                    if (func.Key == val)
                    {
                        func.Value();
                    }
                }
            }
        }
    }
}