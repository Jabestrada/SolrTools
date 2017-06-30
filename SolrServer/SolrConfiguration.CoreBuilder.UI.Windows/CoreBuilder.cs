using SolrConfiguration.Lib.SolrCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolrConfiguration.CoreBuilder.UI.Windows
{
    public partial class CoreBuilder : Form
    {
        public CoreBuilder()
        {
            InitializeComponent();
        }

        private async Task<SolrCoreBuildResult> StartCoreBuild()
        {
            var options = new SolrCoreBuildOption
            {
                SolrBaseUrl = solrServerBaseUrl.Text,
                DataDir = dataDir.Text,
                ConfigFile = configFile.Text,
                SchemaFile = schemaFile.Text,
                CoreNames = coresToCreate.Text
                              .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              .Where(s => !string.IsNullOrWhiteSpace(s))
                              .ToArray()
            };
            var solrCoreBuilder = new SolrCoreBuilder(options);
            return await solrCoreBuilder.Start();
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            // Delete core
            // http://www.ryanwright.me/cookbook/apachesolr/delete-core
            // ./ bin / solr delete - c mysolrcore - p 8983
            try
            {
                var result = await StartCoreBuild();
                // Display results.
                var output = new StringBuilder();
                foreach (var coreResult in result.ResultItems)
                {
                    output.AppendLine(string.Format("{0} | {1}{2}", coreResult.CoreName,
                                        coreResult.Succeeded ? "SUCCEEDED" : "FAILED",
                                        coreResult.Succeeded ? "" : " | " + coreResult.StatusCode));
                }

                results.Text = output.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
