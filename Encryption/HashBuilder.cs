using System.Security.Cryptography;
using System.Text;

namespace SimpleLibraryProject.Encryption
{
    public class HashBuilder
    {
        public static async Task<byte[]> BuildHash(string key, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] pass = Encoding.ASCII.GetBytes(key);
            byte[] s = Encoding.ASCII.GetBytes(salt);
            
            byte[] plainsalted = new byte[pass.Length + s.Length];

            for (int i = 0; i < pass.Length; i++)
            {
                plainsalted[i] = pass[i];
            }
            
            for (int i = 0; i < s.Length; i++)
            {
                plainsalted[pass.Length + i] = s[i];
            }

            return algorithm.ComputeHash(plainsalted);
        }
    }
}