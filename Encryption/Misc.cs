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
    }
}