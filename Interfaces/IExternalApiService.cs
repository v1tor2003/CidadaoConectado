using System.Text.Json;
using System.Text.Json.Nodes;

namespace CidadaoConectado.API.Interfaces
{
    public interface IExternalApiService 
    {
        public Task<JsonDocument?> ExecuteRequestAsync();
        public IExternalApiService CreateRequest(HttpMethod method, string resource);
        public IExternalApiService AddHeader(string key, string value);
        public JsonArray AddIdToJsonArray(JsonDocument jsonDocument);
    }
}