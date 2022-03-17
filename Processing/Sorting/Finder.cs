namespace SimpleLibraryProject.Processing.Sorting
{
    public class Finder<T>
    {
        public static async Task<T> FindMostCommonFromList(List<T> list)
        {
            Dictionary<T, int> count = new();
            
            foreach (T val in list)
            {
                if (count.ContainsKey(val))
                {
                    count[val] = count[val] + 1;
                } else if (!count.ContainsKey(val))
                {
                    count.Add(val, 1);   
                }
            }

            IOrderedEnumerable<KeyValuePair<T, int>> sorted = count.OrderByDescending(x => x.Value);
            List<T> retind = new();

            foreach (KeyValuePair<T, int> val in sorted)
            {
                retind.Add(val.Key);
            }

            return retind[0];
        }
    }
}