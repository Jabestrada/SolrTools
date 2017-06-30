<%@ Page Async="true" Language="c#" Debug="true" MaintainScrollPositionOnPostback="true" %>

<%@ Import Namespace="SolrConfiguration.Lib.ConfigurationCopy" %>
<%@ Import Namespace="System.Threading.Tasks" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title runat="server">Solr Configuration Set Copy v.1</title>
    <link rel="stylesheet" href="/Content/bootstrap.css" />
    <style>
        .row {
            margin-top: 10px;
            margin-bottom: 15px;
        }

        .read-only {
            background-color: cornsilk;
        }

        textarea[readonly="readonly"] {
            background-color: cornsilk;
        }

        .radio-with-caption {
            display: block;
        }

            .radio-with-caption input {
                margin-right: 5px;
            }

        input[type="radio"] + label {
            font-weight: normal;
        }
    </style>
</head>

<body>
    <div class="container">
        <h1 class="text-center">Solr Configuration Set Copy v.1</h1>
        <form id="Form1" runat="server">
            <div class="row">
                <label>Source Solr Config folder</label>
                <asp:TextBox ID="sourceConfigFolder" runat="server"
                    Text="C:\Bitnami\solr-6.6.0-0\apache-solr\server\solr\sitecore_BASELINE_index"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Target ConfigSet Folder</label>
                <asp:TextBox ID="targetConfigSetFolder" runat="server"
                    Text="C:\Bitnami\solr-6.6.0-0\apache-solr\server\solr"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Target Folder Prefix</label>
                <asp:TextBox ID="targetFolderPrefix" runat="server"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Target Folder Suffixes</label>
                <asp:TextBox ID="targetFolderSuffixes" runat="server"
                    TextMode="MultiLine"
                    Text="analytics_index
core_index
fxm_master_index
fxm_web_index
list_index
marketing_asset_index_master
marketing_asset_index_web
marketingdefinitions_master
marketingdefinitions_web
master_index
suggested_test_index
testing_index
web_index"
                    Rows="10"
                    Width="100%" />
            </div>
            <div class="row">
                <asp:Button ID="ProcessJob" CssClass="btn btn-primary" Text="Go" OnClick="CopyConfiguration" runat="server" Width="100%" />
            </div>
            <asp:Label ID="status" runat="server" />
            <div id="resultsContainer" runat="server" visible="false">
                <br />
                <div class="row">
                    <label>Status</label>
                    <asp:TextBox ID="folderStatus" runat="server"
                        TextMode="MultiLine"
                        ReadOnly="true"
                        Rows="10"
                        Width="100%" />
                </div>
                <div class="row">
                    <label>Processed Folders</label>
                    <asp:TextBox ID="processedFolders" runat="server"
                        TextMode="MultiLine"
                        ReadOnly="true"
                        Rows="10"
                        Width="100%" />
                </div>
            </div>
        </form>
    </div>
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
</body>
</html>

<script runat="server">

    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
        base.OnLoad(e);
        Server.ScriptTimeout = int.MaxValue;
    }

    private async Task<ConfigurationCopyResult> StartCopy()
    {
        var options = new ConfigurationCopyOptions
        {
            SourceConfigFolder = sourceConfigFolder.Text,
            TargetConfigSetFolder = targetConfigSetFolder.Text,
            TargetFolderPrefix = targetFolderPrefix.Text,
            TargetFolderSuffixes = targetFolderSuffixes.Text
                            .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .ToArray(),
            Progress = new Progress<ConfigurationCopyProgress>((progress) =>
            {
                if (progress.Status == ConfigurationCopyProgressStatus.ConfigFolderCopyStart)
                {
                    Console.WriteLine(string.Format("Starting copy to {0} ({1} of {2})",
                                        progress.ConfigFolder,
                                        progress.ConfigFolderIndex,
                                        progress.ConfigFolderTotal));
                }
                else if (progress.Status == ConfigurationCopyProgressStatus.ConfigFolderCopyEnd)
                {
                    Console.WriteLine(string.Format("Completed copy to {0}. Status: {1}",
                                    progress.ConfigFolder,
                                    progress.Result.Succeeded ? "OK" : "FAILED"));

                }
            })
        };

        var configCopier = new ConfigurationCopier(options);
        return await configCopier.Start();
    }

    private async void CopyConfiguration(object sender, EventArgs e)
    {
        resultsContainer.Visible = false;
        status.Text = "";
        try
        {
            var result = await StartCopy();
            // Display results.
            var folderNames = new StringBuilder();
            var output = new StringBuilder();
            foreach (var folderResult in result.FolderResults)
            {
                var folderName = System.IO.Path.GetFileName(folderResult.Folder);
                folderNames.AppendLine(folderName);
                output.AppendLine(string.Format("{0} | {1}{2}", folderName,
                                    folderResult.Succeeded ? "SUCCEEDED" : "FAILED",
                                    folderResult.Succeeded ? "" : " | " + folderResult.Reason));
            }
            resultsContainer.Visible = true;
            folderStatus.Text = output.ToString();
            processedFolders.Text = folderNames.ToString();
        }
        catch (Exception exc)
        {
            status.Text = exc.Message;
        }
    }
</script>
