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

        public Task<JsonDocument?> GetFamilyScholarshipsAsync(string yearMonth, string IbgeCode)
        {
            return GetFamilyScholarshipsAsync(yearMonth, IbgeCode, _DEFAULT_QUERY_PAGE);
        }

        public async Task<JsonDocument?> GetFamilyScholarshipsAsync(string yearMonth, string IbgeCode, int page)
        {
            return await CreateRequest(HttpMethod.Get, $"bolsa-familia-por-municipio?mesAno={yearMonth}&codigoIbge={IbgeCode}&pagina={page}")
                        .ExecuteRequestAsync();
        }

        public Task<JsonDocument?> GetParliamentaryAmendmentAsync()
        {
            return GetParliamentaryAmendmentAsync(_DEFAULT_QUERY_PAGE);
        }

        public async Task<JsonDocument?> GetParliamentaryAmendmentAsync(int page)
        {
            return await CreateRequest(HttpMethod.Get, $"emendas?pagina={page}")
                        .ExecuteRequestAsync();
        }

        public Task<JsonDocument?> GetResignValuesAsync()
        {
            return GetResignValuesAsync(_DEFAULT_QUERY_PAGE);
        }

        public async Task<JsonDocument?> GetResignValuesAsync(int page)
        {
            return await CreateRequest(HttpMethod.Get, $"renuncias-valor?pagina={page}")
                        .ExecuteRequestAsync();
        }

        public JsonDocument? MapFamilyScholarshipAsync(JsonDocument jsonDocument)
        {
            var rootElement = jsonDocument.RootElement;
            if(rootElement.ValueKind != JsonValueKind.Array || !rootElement.EnumerateArray().Any())
                return null;

            var element = rootElement[0];

            using var jsonStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(jsonStream))
            {
                writer.WriteStartObject();

                writer.WriteString("codigoIbge", element.GetProperty("municipio").GetProperty("codigoIBGE").GetString());
                writer.WriteString("dataReferencia", element.GetProperty("dataReferencia").GetString());
                writer.WriteNumber("valor", element.GetProperty("valor").GetDecimal());
                writer.WriteNumber("quantidadeBeneficiados", element.GetProperty("quantidadeBeneficiados").GetInt32());

                writer.WriteEndObject();
            }

            jsonStream.Seek(0, SeekOrigin.Begin);
            return JsonDocument.Parse(jsonStream);
        }
    }
}