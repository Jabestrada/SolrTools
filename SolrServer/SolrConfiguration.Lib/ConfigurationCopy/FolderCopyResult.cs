using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.ConfigurationCopy
{
    public class FolderCopyResult
    {
        public string Folder { get; set; }
        public bool Succeeded { get; set; }
        public string Reason { get; set; }
    }
}
