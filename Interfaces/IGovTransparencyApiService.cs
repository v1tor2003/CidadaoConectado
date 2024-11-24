using System.Text.Json;

namespace CidadaoConectado.API.Interfaces
{
    public interface IGovTransparencyApiService : IExternalApiService
    {
        public Task<JsonDocument?> GetResignValues();
        public Task<JsonDocument?> GetResignValues(Int32 page);
    }
}