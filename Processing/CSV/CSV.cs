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

        public async Task WriteToFile(string path)
        {
            string lntowrite = "";
            
            foreach (CSVLine line in SectorList)
            {
                await line.Sectors.SortByAscendingKey();
                foreach (KeyValuePair<int, string> sector in line.Sectors)
                {
                    if (sector.Key == 1)
                    {
                        lntowrite = lntowrite + sector.Value + ",";
                        continue;
                    }

                    if (sector.Key == line.Sectors.Count - 1)
                    {
                        lntowrite = lntowrite + sector.Value;
                        continue;
                    }

                    lntowrite = lntowrite + sector.Value + ",";
                }
                
                File.WriteAllText(path, lntowrite);
                lntowrite = "";
            }
        }
    }
}