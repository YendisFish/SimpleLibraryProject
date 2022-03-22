namespace SimpleLibraryProject.Processing.Sorting
{
    public class Finder<T>
    {
        public static async Task<char> FindMostCommonChar(string str)
        {
            Dictionary<char, int> dict = new();

            foreach (char val in str)
            {
                if (dict.ContainsKey(val))
                {
                    dict[val] = dict[val] + 1;
                }
                else
                {
                    dict.Add(val, 1);
                }
            }

            IOrderedEnumerable<KeyValuePair<char, int>> sorted = dict.OrderByDescending(x => x.Value);

            List<char> ret = new();

            foreach (KeyValuePair<char, int> val in sorted)
            {
                ret.Add(val.Key);
            }

            return ret[0];
        }

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