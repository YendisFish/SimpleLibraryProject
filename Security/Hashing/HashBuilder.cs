using System.Runtime.InteropServices.ComTypes;
using System.Text;
using SimpleLibraryProject.Security.Types;

namespace SimpleLibraryProject.Security.Hashing
{
    public class HashBuilder
    {
        public static async Task<HashOutput> GenerateSecureHash(string password, string salt)
        {
            byte[] basehash = await Encryption.HashBuilder.BuildHash(password, salt);
            byte[] base512 = await Encryption.HashBuilder.BuildHash512(await Encryption.Misc.ByteArrayToString(basehash), salt);

            string torand = Encoding.ASCII.GetString(base512);
            for (int i = 0; i < 5; i++)
            {
                string val1 = await Encryption.Misc.ReverseSequence(Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash(torand, salt)));
                string val2 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val1, salt));
                torand = val2;
            }

            string revrand = await Encryption.Misc.ReverseSequence(torand);
            string hmone = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHashHM512(revrand, salt));

            string ret = torand;
            for (int i = 0; i < 5; i++)
            {
                string val1 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(ret, salt));
                string val2 = await Encryption.Misc.ReverseSequence(Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash(val1, salt)));
                ret = val2;
            }

            return new HashOutput(ret, salt);
        }
    }
}