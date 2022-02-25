using System.Net;

namespace SimpleLibraryProject.Web.DNS
{
    public class Misc
    {
        public static async Task<List<IPAddress>> GetIpsFromUrls(List<string> urls)
        {
            List<IPAddress> ret = new();
            foreach (string url in urls)
            {
                Uri uri = new Uri(url);
                IPAddress ip = Dns.GetHostAddresses(uri.Host)[0];
                ret.Add(ip);
            }

            return ret;
        }
    }
}