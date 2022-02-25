namespace SimpleLibraryProject.Builders
{
    public class ClassBuilder
    {
        public string Namespace { get; set; }
        public string Filename { get; set; }
        public string ClassName { get; set; }
        public Dictionary<string, string> Values { get; set; }
        public List<string> Imports { get; set; }

        public ClassBuilder(string Namespace, string filename, string className, Dictionary<string, string> values, List<string> imports)
        {
            this.Namespace = Namespace;
            this.Filename = filename;
            this.ClassName = className;
            this.Values = values;
            this.Imports = imports;
        }

        public static async Task SimpleClass(ClassBuilder builder)
        {
            List<string> template = await ClassBuilderData.Templates.SimpleTemplate.BuildTemplate();
            List<string> result = new();
            
            foreach (string line in template)
            {
                if (line.Contains("<IMPORTREGION>"))
                {
                    foreach (string import in builder.Imports)
                    {
                        result.Add($"using {import.Trim()}");
                    }
                }

                if (line.Contains("namespace <REPLACEME>"))
                {
                    result.Add(line.Replace("<REPLACEME>", builder.Namespace));
                }
                
                if(line.Contains("public class <REPLACEME>")) 
                {
                    result.Add(line.Replace("<REPLACEME>", builder.ClassName));
                }

                if (line.Contains("<VALUEREGION>"))
                {
                    foreach (KeyValuePair<string, string> val in builder.Values)
                    {
                        result.Add(val.Value + " " + val.Key + " " + " { get; set; }");
                    }
                }

                if (line.Contains("public <REPLACEME>(<ENTER VALUES>)"))
                {
                    string newline = line.Replace("<REPLACEME>", builder.ClassName).Replace("(<ENTER VALUES>)", "") + "(";
                    
                    foreach (KeyValuePair<string, string> val in builder.Values)
                    {
                        newline = newline + $"{val.Value} {val.Key.ToLower()}, ";
                    }

                    newline.ReplaceLineEndings("||");
                    newline.Replace(", ||", ")");
                }
            }
        }
    }
}