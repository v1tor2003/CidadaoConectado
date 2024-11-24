

using System.Text.Json;
using CidadaoConectado.API.Interfaces;

namespace CidadaoConectado.API.Services
{
    public class GovTransparencyApiService : ExternalApiService, IGovTransparencyApiService
    {
        private readonly int _DEFAULT_QUERY_PAGE = 1;
        public GovTransparencyApiService(HttpClient httpClient) 
        : base(httpClient) 
        {}

        public Task<JsonDocument?> GetResignValues()
        {
            return GetResignValues(_DEFAULT_QUERY_PAGE);
        }

        public async Task<JsonDocument?> GetResignValues(int page)
        {
            return await CreateRequest(HttpMethod.Get, $"renuncias-valor?pagina={page}")
                        .ExecuteRequestAsync();
        }
    }
}