using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CP380_B3_BlockBlazor.Data
{
    public class BlockService
    {
        
        static HttpClient _httpClient;  //       - httpClient

        private IConfiguration  configuration_c;    //       - configuration
        //

        public BlockService(IHttpClientFactory HttpClientFactory, IConfiguration Configuration )
        {
            _httpClient = HttpClientFactory.CreateClient();
           configuration_c= Configuration.GetSection("BlockService");
        }
        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //

        public async Task<IEnumerable<Block>> GetBlock()
        {   
            var answer = await _httpClient.GetAsync(configuration_c["url"]);
            if (answer.IsSuccessStatusCode)
            {
                if (answer.IsSuccessStatusCode)
                {
                    JsonSerializerOptions con = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Block>>(
                            await answer.Content.ReadAsStreamAsync(), con
                        );
                }

                return Array.Empty<Block>();

            }
            //
            // TODO: Add an async method that returns an IEnumerable<Block> (list of Blocks)
            //       from the web service
            //

            public async Task<Block> SubmitNewBlockAsync(Block block)
            {
                var data = new StringContent(
                        JsonSerializer.Serialize(block,configuration_c),
                        System.Text.Encoding.UTF8,
                        "application/json"
                        );
                var response = await _httpClient.PostAsync(configuration_c["url"], data);  return (response.IsSuccessStatusCode) ? block : null;
            }
        }
}
}
