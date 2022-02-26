using System.Net;

namespace SimpleLibraryProject.Web
{
    public class Downloader
    {
        public static async Task BasicDownload(string Url, string Filename)
        {
            WebClient client = new WebClient();
            client.DownloadFile(Url, Filename);
        }
    }
}