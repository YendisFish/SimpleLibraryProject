using System.Security.Cryptography;
using System.Text;

namespace SimpleLibraryProject.Encryption
{
    public class Misc
    {
        public static async Task<string> ByteArrayToString(byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }

        public static async Task<string> ReverseSequence(string val)
        {
            string ret = "";

            for (int i = val.Length - 1; i >= 0; i--)
            {
                ret = ret + val[i];
            }

            return ret;
        }

        public static async Task<string> RandomizeString(string value)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] bits = new byte[value.Length * 2];
            rng.GetBytes(bits);
            
            List<char> converted = new();
            
            Dictionary<int, char> table = new();

            for (int i = 0; i < value.Length; i++)
            {
                if (table.ContainsKey(bits[i] * bits[i * 2]))
                {
                    continue;
                }
                
                table.Add(bits[i] * bits[i * 2], value[i]);
            }

            IOrderedEnumerable<KeyValuePair<int, char>> table2 = table.OrderByDescending(x => x.Key);

            string ret = "";
            foreach (KeyValuePair<int, char> v in table2)
            {
                ret = ret + v.Value;
            }

            return ret;
        }
    }
}