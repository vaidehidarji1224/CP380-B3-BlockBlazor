using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;


namespace CP380_B3_BlockBlazor.Data
{
    public class PendingTransactionService
    {
        public class PendingTransactionService
        {
            static HttpClient _httpClient;
            private readonly IConfiguration configure;
            private readonly JsonSerializerOptions configc= new JsonSerializerOptions(JsonSerializerDefaults.Web);

            public PendingTransactionService(IHttpClientFactory HttpClientFactory, IConfiguration _config)
            {
                _httpClient = HttpClientFactory.CreateClient();
                configure = _config.GetSection("PayloadService");
            }

            public async Task<IEnumerable<Payload>> GetPayloadsAsync()
            {
                var result= await _httpClient.GetAsync(configure["http://localhost:5000/PendingPayloads"]);

                if (result.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Payload>>(
                         await responce.Content.ReadAsStreamAsync(),result
                         );
                }

                return Array.Empty<Payload>();
            }

            public async Task<HttpResponseMessage> AddPayloadAsync(Payload payload)
            {
                var content = new StringContent(
                        JsonSerializer.Serialize(payload, configc),
                        System.Text.Encoding.UTF8,
                        "application/json"
                        );
                var response = await _httpClient.PostAsync(configure["url"], content);
                return response;
            }
        }
}
