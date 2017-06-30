using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.SolrCore
{
    public class SolrCoreBuildResult
    {
        public SolrCoreBuildResult()
        {
            ResultItems = new List<SolrCoreBuildResultItem>();
        }
        public List<SolrCoreBuildResultItem> ResultItems { get; set; }
    }
}
