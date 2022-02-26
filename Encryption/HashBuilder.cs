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
        
        public static async Task<byte[]> BuildHash512(string key, string salt)
        {
            HashAlgorithm algorithm = new SHA512Managed();

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
        
        public static async Task<byte[]> BuildHashHM384(string key, string salt)
        {
            HashAlgorithm algorithm = new HMACSHA384();

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
        
        public static async Task<byte[]> BuildHashHM512(string key, string salt)
        {
            HashAlgorithm algorithm = new HMACSHA512();

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
        
        public static async Task<byte[]> BuildHashHM256(string key, string salt)
        {
            HashAlgorithm algorithm = new HMACSHA256();

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
        
        public static async Task<byte[]> BuildHashMD5(string key, string salt)
        {
            HashAlgorithm algorithm = new MD5CryptoServiceProvider();

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