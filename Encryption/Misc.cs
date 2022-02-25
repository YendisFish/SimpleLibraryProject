using System.Text;

namespace SimpleLibraryProject.Encryption
{
    public class Misc
    {
        public static async Task<string> ByteArrayToString(byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }
    }
}