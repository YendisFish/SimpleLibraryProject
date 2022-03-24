using SimpleLibraryProject.Builders.TabledefData;

namespace SimpleLibraryProject.Builders
{
    public class CSLTabledefBuilder
    {
        public string Namespace { get; set; }
        public string TableName { get; set; }
        public TDPK PrimaryKey { get; set; }
        public List<string> Vals { get; set; }
        private List<string> FinalWrite { get; set; }

        public CSLTabledefBuilder(string nspace, string tablename)
        {
            Namespace = nspace;
            TableName = tablename;
        }
        
        public async Task SetPK(string name, string type)
        {
            PrimaryKey = new TDPK(type, name);
        }

        public async Task InsertVal(string name, string type)
        {
            if (type != "BIGINT")
            {
                Vals.Add($"{name} = {type.ToUpper()}");
            }

            if (type == "BIGINT")
            {
                Vals.Add($"{name} = LONG");
            }
        }

        public async Task BuildFile(string name)
        {
            File.Create(name).Close();
            
            File.AppendAllText(name, "[Metadata]");
            
            FinalWrite.Add($"Namespace = {Namespace}");
            FinalWrite.Add($"Table Name = {TableName}");

            foreach (string val in Vals)
            {
                FinalWrite.Add(val);
            }

            File.AppendAllText(name, "[Columns]");
            File.WriteAllText(name, $"{PrimaryKey.Name} = {PrimaryKey.Type}");
            
            foreach (string val in FinalWrite)
            {
                File.AppendAllText(name, val);
            }
        }
    }
}