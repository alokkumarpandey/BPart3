using LabEntity.Shared;

namespace BlazorDemoPart2.Client.DataServices
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
