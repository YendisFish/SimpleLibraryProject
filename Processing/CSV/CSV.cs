namespace SimpleLibraryProject.Processing.CSV
{
    public class CSV
    {
        public string Path { get; set; }
        public string Raw { get; set; }
        public string[] Lines { get; set; }
        public List<CSVLine>? SectorList { get; set; }

        public CSV(string path)
        {
            this.Path = path;
            this.Raw = File.ReadAllText(path);
            this.Lines = File.ReadAllLines(path);

            ImportLines().GetAwaiter().GetResult();
        }

        public async Task ImportLines()
        {
            foreach (string val in Lines)
            {
                CSVLine ln = new CSVLine();
                await ln.ParseSet(val);

                this.SectorList?.Add(ln ?? null);
            }
        }
    }
}