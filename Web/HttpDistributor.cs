using System.Net.Http.Json;

namespace SimpleLibraryProject.Web
{
    public class HttpDistributor<T>
    {
        public static async Task DistributeInformation(List<string> urls, T info)
        {
            HttpClient client = new();

            foreach (string url in urls)
            {
                await client.PostAsJsonAsync(url, info);
            }
        }
    }
}