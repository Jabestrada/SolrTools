using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.ConfigurationCopy
{
    public class ConfigurationCopier
    {
        private ConfigurationCopyOptions _options;
        private IProgress<ConfigurationCopyProgress> _progress;

        public ConfigurationCopier(ConfigurationCopyOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.TargetFolderPrefix))
            {
                throw new InvalidOperationException("ConfigurationCopyOptions.TargetFolderPrefix cannot be null");
            }
            _options = options;
            _progress = options.Progress;
        }

        public async Task<ConfigurationCopyResult> Start()
        {
            return await Task.Run(() =>
            {
                var result = new ConfigurationCopyResult { ConfigurationCopyOptions = _options};
                var total = _options.TargetFolderSuffixes.Length;
                var currentIndex = 0;
                foreach (var configFolderSuffix in _options.TargetFolderSuffixes)
                {
                    currentIndex++;
                    var configFolderName = _options.TargetFolderPrefix + configFolderSuffix;
                    var configFolder = Path.Combine(_options.TargetConfigSetFolder, configFolderName);
                    reportProgress(new ConfigurationCopyProgress {
                        ConfigFolder = configFolderName,
                        Status = ConfigurationCopyProgressStatus.ConfigFolderCopyStart,
                        ConfigFolderIndex = currentIndex,
                        ConfigFolderTotal = total
                    });
                    FolderCopyResult copyResult = null;
                    try
                    {
                        CopyDir.Copy(_options.SourceConfigFolder, configFolder);
                        copyResult = new FolderCopyResult
                        {
                            Folder = configFolder,
                            Succeeded = true
                        };
                        result.FolderResults.Add(copyResult);
                    }
                    catch (Exception exc)
                    {
                        copyResult = new FolderCopyResult
                        {
                            Folder = configFolder,
                            Succeeded = false,
                            Reason = exc.Message
                        };
                        result.FolderResults.Add(copyResult);
                    }
                    reportProgress(new ConfigurationCopyProgress
                    {
                        ConfigFolder = configFolderName,
                        Status = ConfigurationCopyProgressStatus.ConfigFolderCopyEnd,
                        Result = copyResult,
                        ConfigFolderIndex = currentIndex,
                        ConfigFolderTotal = total
                    });
                }
                return result;
            }
            );
        }

        private void reportProgress(ConfigurationCopyProgress progress)
        {
            if (_progress != null)
            {
                _progress.Report(progress);
            }
        }

    }
}
