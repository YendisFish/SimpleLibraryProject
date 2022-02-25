using System.Net;

namespace SimpleLibraryProject.Web.Types
{
    public class Blacklist
    {
        public List<string> Urls { get; set; }
        public List<IPAddress> IPAddresses { get; set; }
    }
}