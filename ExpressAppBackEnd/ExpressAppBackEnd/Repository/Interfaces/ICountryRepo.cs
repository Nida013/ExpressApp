using ExpressAppBackEnd.Dtos;

namespace ExpressAppBackEnd.Repository.Interfaces
{
    public interface ICountryRepo
    {
        Task<CountryData> GetCountriesListAsync();

        Task<Country> GetCountryById(int countryId);

        Task<List<string>> GetContinents();

        Task AddCountry(Country country);
        
    }
}
