using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.ConfigurationCopy
{
    public class ConfigurationCopyProgress
    {
        public string ConfigFolder { get; set; }
        public int ConfigFolderIndex { get; set; }
        public int ConfigFolderTotal { get; set; }
        public ConfigurationCopyProgressStatus Status { get; set; }
        public FolderCopyResult Result { get; set; }
    }
}
