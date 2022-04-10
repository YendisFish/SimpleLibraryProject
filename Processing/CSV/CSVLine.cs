using SimpleLibraryProject.Processing.Sorting;

namespace SimpleLibraryProject.Processing.CSV
{
    public class CSVLine
    {
        public SortableDictionary<int, string> Sectors { get; set; }

        public async Task ParseSet(string raw)
        {
            raw.ReplaceLineEndings("]");

            bool foundterminalchar = false;

            List<string> vals = new();
            string current = "";
            while (!foundterminalchar)
            {
                foreach (char val in raw)
                {
                    if (val != ',')
                    {
                        current = current + val;
                    }

                    if (val == ',')
                    {
                        current = "";
                    }

                    if (val == ']')
                    {
                        foundterminalchar = true;
                        break;
                        throw new Exception("Out of loop bounds!");
                    }
                }
            }

            for (int i = 0; i <= vals.Count; i++)
            {
                await Sectors.InsertAsync(i, vals[i]);
            }
        }
    }
}