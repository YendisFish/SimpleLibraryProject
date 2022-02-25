using System.Net.Http.Json;

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

        public static async Task PostPassword(string url, string password, string salt)
        {
            HttpClient client = new HttpClient();
            byte[] hash = await Encryption.HashBuilder.BuildHash(password, salt);

            await client.PostAsJsonAsync(url, hash);
        }
    }
}