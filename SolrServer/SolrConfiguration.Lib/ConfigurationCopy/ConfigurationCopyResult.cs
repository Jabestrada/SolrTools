using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.ConfigurationCopy
{
    public class ConfigurationCopyResult
    {
        public ConfigurationCopyOptions ConfigurationCopyOptions { get; set; }
        public List<FolderCopyResult> FolderResults { get; protected set; }

        public ConfigurationCopyResult()
        {
            FolderResults = new List<FolderCopyResult>();
        }

       

    }
}
