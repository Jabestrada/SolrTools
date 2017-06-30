<%@ Page Async="true" Language="c#" Debug="true" MaintainScrollPositionOnPostback="true" %>

<%@ Import Namespace="SolrConfiguration.Lib.SolrCore" %>
<%@ Import Namespace="System.Threading.Tasks" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title runat="server">Solr Core Builder v.1</title>
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
        <h1 class="text-center">Solr Core Builder v.1</h1>
        <form id="Form1" runat="server">
            <div class="row">
                <label>Solr Server URL</label>
                <asp:TextBox ID="solrServerBaseUrl" runat="server"
                    Text="http://localhost:8983/solr"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Config File</label>
                <asp:TextBox ID="configFile" runat="server"
                    Text="solrconfig.xml"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Schema File</label>
                <asp:TextBox ID="schemaFile"
                    Text="schema.xml"
                    runat="server"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Data Dir</label>
                <asp:TextBox ID="dataDir"
                    Text="data"
                    runat="server"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Cores To Create (These folders should exist in Solr server; use SolrConfigCopy.aspx)</label>
                <asp:TextBox ID="coresToCreate" runat="server"
                    TextMode="MultiLine"
                    Rows="10"
                    Width="100%" />
            </div>
            <div class="row">
                <asp:Button ID="GoButton" CssClass="btn btn-primary" Text="Go" OnClick="CreateCores" runat="server" Width="100%" />
            </div>
            <asp:Label ID="status" runat="server" />
            <div id="resultsContainer" runat="server" visible="false">
                <br />
                <div class="row">
                    <label>Results</label>
                    <asp:TextBox ID="results" runat="server"
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

    private async Task<SolrCoreBuildResult> Start()
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

    private async void CreateCores(object sender, EventArgs e)
    {
        // Delete core
        // http://www.ryanwright.me/cookbook/apachesolr/delete-core
        // ./ bin / solr delete -c mysolrcore -p 8983
        try
        {
            var result = await Start();
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
            results.Text = "FAILED: " + exc.Message;
        }
        resultsContainer.Visible = true;
    }
</script>
