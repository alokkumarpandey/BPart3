using LabEntity.Shared;
using System.Text.Json;

namespace BlazorDemoPart2.Client.DataServices
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient = default!;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                 (await _httpClient.GetStreamAsync($"api/countries"), 
                 new JsonSerializerOptions() 
                 { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/countries{countryId}"),
                new JsonSerializerOptions() 
                { PropertyNameCaseInsensitive = true });
        }
    }
}
