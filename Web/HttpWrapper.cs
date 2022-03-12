using System.Net.Http.Json;
using System.Text;
using SimpleLibraryProject.Security.Types;

namespace SimpleLibraryProject.Web
{
    public class HttpWrapper<T>
    {
        public static async Task QuickPostAsJson(string url, T info)
        {
            HttpClient client = new HttpClient();
            await client.PostAsJsonAsync(url, info);
        }

        public static async Task<T> QuickGetAsJson(string url)
        {
            HttpClient client = new HttpClient();
            T val = await client.GetFromJsonAsync<T>(url);
            return val;
        }

        public static async Task PostPassword(string url, string password)
        {
            string salt = Encoding.ASCII.GetString(await Security.Hashing.SaltBuilder.BuildSalt());
            
            HttpClient client = new HttpClient();
            HashOutput hash = await Security.Hashing.HashBuilder.CompletelyDestroyMyDataHash(password, salt);

            await client.PostAsJsonAsync(url, hash);
        }
    }
}