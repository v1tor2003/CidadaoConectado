using System.Text.Json;
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
           
            if (!IsResponseContentJson(response))
            {
                Console.WriteLine("Response is not JSON. Cannot parse.");
                return null;
            }

            try
            {
                return JsonDocument.Parse(contentResponse);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse JSON: {ex.Message}");
                throw;
            }
        }

        private static bool IsResponseContentJson(HttpResponseMessage response)
        {
            return response.Content.Headers.ContentType?.MediaType?.Contains("application/json") ?? false;
        }
    }
}