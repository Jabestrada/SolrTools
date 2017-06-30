using System;
using System.Collections.Generic;
using System.Text;

namespace SolrConfiguration.Lib.ConfigurationCopy
{
    public class ConfigurationCopyOptions
    {
        public string SourceConfigFolder { get; set; }
        public string TargetConfigSetFolder { get; set; }
        public string TargetFolderPrefix { get; set; }
        public string[] TargetFolderSuffixes { get; set; }

        public IProgress<ConfigurationCopyProgress> Progress { get; set; }
    }
}
