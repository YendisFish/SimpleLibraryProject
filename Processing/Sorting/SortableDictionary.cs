using System.Collections;

namespace SimpleLibraryProject.Processing.Sorting
{
    public class SortableDictionary<Tkey, Tval> : List<KeyValuePair<Tkey, Tval>>
    {
        public List<KeyValuePair<Tkey, Tval>> values { get; set; }
        
        public SortableDictionary()
        {
            values = new List<KeyValuePair<Tkey, Tval>>();
        }
        
        public IEnumerator<KeyValuePair<Tkey, Tval>> GetEnumerator()
        {
            return values.GetEnumerator();
        }
        
        public async Task InsertAsync(Tkey key, Tval val)
        {
            KeyValuePair<Tkey, Tval> toinsert = new KeyValuePair<Tkey, Tval>(key, val);
            values.Add(toinsert);
        }
        
        
        public async Task InsertAsync(KeyValuePair<Tkey, Tval> val)
        {
            values.Add(val);
        }

        public async Task AddRangeAsync(Dictionary<Tkey, Tval> vals)
        {
            foreach (KeyValuePair<Tkey, Tval> val in vals)
            {
                 values.Add(val);
            }
        }

        public async Task DeleteKeyByVal(Tval value)
        {
            List<KeyValuePair<Tkey, Tval>> ret = new();
            foreach (KeyValuePair<Tkey, Tval> val in values)
            {
                if (!value.Equals(val))
                {
                    ret.Add(val);
                }
            }
        }

        public async Task<bool> ContainsKey(Tkey key)
        {
            foreach (KeyValuePair<Tkey, Tval> val in values)
            {
                if (key.Equals(val.Key))
                {
                    return true;
                }
            }

            return false;
        }
        
        public async Task<bool> ContainsVal(Tval value)
        {
            foreach (KeyValuePair<Tkey, Tval> val in values)
            {
                if (value.Equals(val.Key))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task AddKeyRange(List<Tkey> keys)
        {
            foreach (Tkey val in keys)
            {
                values.Add(new KeyValuePair<Tkey, Tval>(val, default));
            }
        }

        public async Task SortByDescendingKey()
        {
            try
            {
                if (typeof(Tval) == typeof(int))
                {
                    IOrderedEnumerable<KeyValuePair<Tkey, Tval>> sorted = values.OrderByDescending(x => x.Key);
                    values = new List<KeyValuePair<Tkey, Tval>>();

                    foreach (KeyValuePair<Tkey, Tval> val in sorted)
                    {
                        values.Add(val);
                    }
                }
                else
                {
                    throw new Exception("Key must be of type integer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public async Task SortKeyAlphabetically()
        {
            IOrderedEnumerable<KeyValuePair<Tkey, Tval>> sorted = values.OrderBy(x => x.Key);
            values = new List<KeyValuePair<Tkey, Tval>>();

            foreach (KeyValuePair<Tkey, Tval> val in sorted)
            {
                values.Add(val);
            }
        }
        
        public async Task SortValueAlphabetically()
        {
            try
            {
                if (typeof(Tval) == typeof(string))
                {
                    IOrderedEnumerable<KeyValuePair<Tkey, Tval>> sorted = values.OrderBy(x => x.Value);
                    values = new List<KeyValuePair<Tkey, Tval>>();

                    foreach (KeyValuePair<Tkey, Tval> val in sorted)
                    {
                        values.Add(val);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public async Task SortByDescendingValue()
        {
            try
            {
                if (typeof(Tval) == typeof(int))
                {
                    IOrderedEnumerable<KeyValuePair<Tkey, Tval>> sorted = values.OrderByDescending(x => x.Value);
                    values = new List<KeyValuePair<Tkey, Tval>>();

                    foreach (KeyValuePair<Tkey, Tval> val in sorted)
                    {
                        values.Add(val);
                    }
                }
                else
                {
                    throw new Exception("Value must be of type integer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}