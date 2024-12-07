using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;
        private HttpRequestMessage _request;
        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _request = new HttpRequestMessage();
        }

        public IExternalApiService AddHeader(string key, string value)
        {
            _request.Headers.Add(key, value);
            return this;
        }

        public IExternalApiService CreateRequest(HttpMethod method, string resource)
        {
            var requestUrl = $"{_httpClient.BaseAddress}/{resource}";
            _request = new HttpRequestMessage(method, requestUrl);
           
            return this;
        }

        public async Task<JsonDocument?> ExecuteRequestAsync()
        {
            var response = await _httpClient.SendAsync(_request); 
            if(!response.IsSuccessStatusCode) return null;

            var contentResponse = await response.Content.ReadAsStringAsync();
            if (!IsResponseContentJson(response)) return JsonDocument.Parse("{}");
            
            var jsonDocument = JsonDocument.Parse(contentResponse);
            var rootElement = jsonDocument.RootElement;

            if(rootElement.ValueKind == JsonValueKind.Array)
            {
                var indexedJsonArray = AddIdToJsonArray(jsonDocument);
                return JsonDocument.Parse(indexedJsonArray.ToJsonString());
            }

            return JsonDocument.Parse(contentResponse);
        }

        private static bool IsResponseContentJson(HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType?.MediaType?.Contains("application/json") ?? false;
        }
        
        public JsonArray AddIdToJsonArray(JsonDocument jsonDocument)
        {
            var jsonArray = new JsonArray();

            int index = 1;
            foreach(var item in jsonDocument.RootElement.EnumerateArray())
            {
                var jsonObject = JsonObject.Create(item);
                if(jsonObject is not null)
                {
                    if(!jsonObject.ContainsKey("id"))
                        jsonObject["id"] = index++;

                    jsonArray.Add(jsonObject);
                }
            }

            return jsonArray;
        }
    }
}