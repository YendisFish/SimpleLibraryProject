using System.Net;

namespace SimpleLibraryProject.Web.Types
{
    public class Blacklist
    {
        public List<string> Urls { get; set; }
        public List<IPAddress> IPAddresses { get; set; }

        public Blacklist(List<string> urls, List<IPAddress> addrs)
        {
            this.Urls = urls;
            this.IPAddresses = addrs;
        }
    }
}