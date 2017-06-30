using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.SolrCore
{
    public class SolrCoreBuildOption
    {
        public string SolrBaseUrl { get; set; }
        public string[] CoreNames { get; set; }
        public string DataDir { get; set; }
        public string ConfigFile { get; set; }
        public string SchemaFile { get; set; }
    }
}
