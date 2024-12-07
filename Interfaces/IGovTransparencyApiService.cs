using System.Text.Json;
using System.Text.Json.Nodes;

namespace CidadaoConectado.API.Interfaces
{
    public interface IGovTransparencyApiService : IExternalApiService
    {
        public Task<JsonDocument?> GetResignValuesAsync();
        public Task<JsonDocument?> GetResignValuesAsync(Int32 page);
        public Task<JsonDocument?> GetParliamentaryAmendmentAsync();
        public Task<JsonDocument?> GetParliamentaryAmendmentAsync(Int32 page);

        public Task<JsonDocument?> GetFamilyScholarshipsAsync(string yearMonth, string IbgeCode);
        public Task<JsonDocument?> GetFamilyScholarshipsAsync(string yearMonth, string IbgeCode, Int32 page);
    }
}