using System.Text.Json;

namespace CidadaoConectado.API.Interfaces
{
    public interface IExternalApiService 
    {
        public Task<JsonDocument?> ExecuteRequestAsync();
        public IExternalApiService CreateRequest(HttpMethod method, string resource);
        public IExternalApiService AddHeader(string key, string value);
    }
}