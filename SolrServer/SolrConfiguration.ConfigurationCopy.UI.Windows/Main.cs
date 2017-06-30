using SolrConfiguration.Lib.ConfigurationCopy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolrConfiguration.UI.Windows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async Task<ConfigurationCopyResult> StartCopy() {
            var options = new ConfigurationCopyOptions
            {
                SourceConfigFolder = sourceConfigFolder.Text,
                TargetConfigSetFolder = targetConfigSetFolder.Text,
                TargetFolderPrefix = targetFolderPrefix.Text,
                TargetFolderSuffixes = targetFolderSuffixes.Text
                                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .ToArray(),
                Progress = new Progress<ConfigurationCopyProgress>((progress) => {
                    if (progress.Status == ConfigurationCopyProgressStatus.ConfigFolderCopyStart)
                    {
                        Console.WriteLine(string.Format("Starting copy to {0} ({1} of {2})", 
                                            progress.ConfigFolder,
                                            progress.ConfigFolderIndex,
                                            progress.ConfigFolderTotal));
                    } else if (progress.Status == ConfigurationCopyProgressStatus.ConfigFolderCopyEnd) {
                        Console.WriteLine(string.Format("Completed copy to {0}. Status: {1}", 
                                        progress.ConfigFolder,
                                        progress.Result.Succeeded ? "OK" : "FAILED"));

                    }
                })
            };

            var configCopier = new ConfigurationCopier(options);
            return await configCopier.Start();
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await StartCopy();
                // Display results.
                var output = new StringBuilder();
                foreach(var folderResult in result.FolderResults)
                {
                    output.AppendLine(string.Format("{0} | {1}{2}", folderResult.Folder, 
                                        folderResult.Succeeded ? "SUCCEEDED": "FAILED",
                                        folderResult.Succeeded ? "" : " | " + folderResult.Reason));
                }

                MessageBox.Show(output.ToString());
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
