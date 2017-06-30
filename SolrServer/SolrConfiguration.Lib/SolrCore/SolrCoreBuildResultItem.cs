using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.SolrCore
{
    public class SolrCoreBuildResultItem
    {
        public string CoreName { get; set; }
        public string RequestUri { get; set; }
        public bool Succeeded { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
    }
}
