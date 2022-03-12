using System.Net.Http.Json;
using SimpleLibraryProject.Web.Types;

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

        public static async Task DistributeExcludingBlackList(List<string> urls, T info, Blacklist blacklist)
        {
            HttpClient client = new();

            foreach (string url in urls)
            {
                if (blacklist.Urls.Contains(url))
                {
                    continue;
                }

                await client.PostAsJsonAsync(url, info);
            }
        }
    }
}