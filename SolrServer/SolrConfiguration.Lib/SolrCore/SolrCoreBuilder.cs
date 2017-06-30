using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SolrConfiguration.Lib.SolrCore
{
    public class SolrCoreBuilder
    {
        private SolrCoreBuildOption _options;
        private const string CREATE_CORE_REQUEST = "{0}/admin/cores?action=CREATE&name={1}&instanceDir={1}&config={2}&schema={3}&dataDir={4}";

        public SolrCoreBuilder(SolrCoreBuildOption options)
        {
            _options = options;
            setDefaultOptions();
        }

        public async Task<SolrCoreBuildResult> Start() {

            return await Task.Run(async() =>
            {
                var result = new SolrCoreBuildResult();
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(_options.SolrBaseUrl);
                    // SOURCE: https://wiki.apache.org/solr/CoreAdmin#CREATE
                    // http://localhost:8983/solr/admin/cores?action=CREATE&name=coreX
                    // &instanceDir=path_to_instance_directory&config=config_file_name.xml&schema=schema_file_name.xml&dataDir=data
                    foreach (var core in _options.CoreNames) {
                        var createCoreRequest = string.Format(CREATE_CORE_REQUEST, 
                                                            _options.SolrBaseUrl, 
                                                            core, 
                                                            _options.ConfigFile,
                                                            _options.SchemaFile,
                                                            _options.DataDir);
                        var response = await client.GetAsync(createCoreRequest);
                        result.ResultItems.Add(new SolrCoreBuildResultItem
                        {
                            CoreName = core,
                            RequestUri = createCoreRequest,
                            Succeeded = response.IsSuccessStatusCode,
                            StatusCode = response.StatusCode,
                            ReasonPhrase = response.ReasonPhrase
                        });
                    }
                }
                    return result;
            }
            );
        }

        private void setDefaultOptions() {
            if (string.IsNullOrWhiteSpace(_options.ConfigFile))
            {
                _options.ConfigFile = "solrconfig.xml";
            }
            if (string.IsNullOrWhiteSpace(_options.SchemaFile))
            {
                _options.SchemaFile = "schema.xml";
            }
            if (string.IsNullOrWhiteSpace(_options.DataDir))
            {
                _options.DataDir = "data";
            }
        }

    }
}
