namespace SimpleLibraryProject.Processing.Sorting
{
    public class Sorter<T>
    {
        public static async Task<List<DateTime>> OrderListByDate(List<DateTime> list)
        {
            IOrderedEnumerable<DateTime> enumerable = list.OrderByDescending(x => x.Date);
            
            List<DateTime> ret = new();
            ret.AddRange(enumerable);

            return ret;
        }

        public static async Task<List<string>> OrderAlphabetically(List<string> list)
        {
            List<string> ret = list.OrderBy(x => x).ToList();
            return ret;
        }

        public static async Task<List<T>> OrderByOccurrence(List<T> list)
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

            List<T> ret = new();
            
            foreach (KeyValuePair<T, int> val in sorted)
            {
                ret.Add(val.Key);
            }

            return ret;
        }
    }
}