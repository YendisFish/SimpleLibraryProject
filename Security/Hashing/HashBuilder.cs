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
            for (int i = 0; i < 50000; i++)
            {
                string val1 = await Encryption.Misc.ReverseSequence(Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash(torand, salt)));
                string val2 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val1, salt));
                torand = val2;
            }

            string revrand = await Encryption.Misc.ReverseSequence(torand);
            string hmone = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHashHM512(revrand, salt));

            string ret = torand;
            for (int i = 0; i < 50000; i++)
            {
                string val1 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(ret, salt));
                string val2 = await Encryption.Misc.ReverseSequence(Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash(val1, salt)));
                string val3 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHashMD5(val2, salt));
                ret = val2;
            }

            return new HashOutput(ret, salt);
        }

        public static async Task<HashOutput> QuickSecureHash(string password)
        {
            byte[] bsalt = await Security.Hashing.SaltBuilder.BuildSalt();
            string salt = Encoding.ASCII.GetString(bsalt);

            string basehash = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(password, salt));

            string endput = "";
            for (int i = 0; i < 20000; i++)
            {
                string val1 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(password, salt));
                string val2 = await Encryption.Misc.ReverseSequence(val1);
                string val3 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val2, salt));
                endput = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val3, salt));
            }

            return new HashOutput(endput, salt);
        }

        public static async Task<HashOutput> CompletelyDestroyMyDataHash(string password, string salt)
        {
            string charhsh = "";
            foreach (char val in password)
            {
                string ch = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val.ToString(), salt));
                charhsh = charhsh + ch;
            }

            string rehashed = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(charhsh, salt));

            string endout = "";
            for (int i = 0; i < 100000; i++)
            {
                string val1 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(rehashed, salt));
                string val2 = await Encryption.Misc.ReverseSequence(val1);
                string val3 = Encoding.ASCII.GetString(await Encryption.HashBuilder.BuildHash512(val2, salt));

                endout = val3;
            }

            return new HashOutput(endout, salt);
        }
    }
}