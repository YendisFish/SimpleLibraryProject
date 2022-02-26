using System.Security.Cryptography;
using System.Text;

namespace SimpleLibraryProject.Security.Hashing
{
    public class SaltBuilder
    {
        public static async Task<byte[]> BuildSalt()
        {
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            
            byte[] salt = new byte[6000];
            generator.GetBytes(salt);
            
            return await Encryption.HashBuilder.BuildHash(Encoding.ASCII.GetString(salt), "abcdefg");
        }
    }
}