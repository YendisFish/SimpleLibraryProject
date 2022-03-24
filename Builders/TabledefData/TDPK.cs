namespace SimpleLibraryProject.Builders.TabledefData
{
    public class TDPK
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public TDPK(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}