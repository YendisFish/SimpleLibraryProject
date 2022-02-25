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
    }
}