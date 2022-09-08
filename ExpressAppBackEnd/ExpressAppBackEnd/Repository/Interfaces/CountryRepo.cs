using ExpressAppBackEnd.Dtos;
using Newtonsoft.Json;
using System.Drawing;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ExpressAppBackEnd.Repository.Interfaces
{
    public class CountryRepo : ICountryRepo
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string RootPath;

        public CountryRepo(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            RootPath = _hostingEnvironment.ContentRootPath;
        }

        public async Task AddCountry(Country country)
        {
            var getCountryList = _GetCountryListData();

            getCountryList.Countries.Add(new Country
            {
                Name = country.Name,
                Continent = country.Continent,
                Flag = "images/" + country.Name + ".png",
                Rank = country.Rank
            });

            var newCountryAddedToList = JsonConvert.SerializeObject(getCountryList, Formatting.Indented);

            var fullPath = Path.Combine(RootPath, "data/data.json");

            var fullImagePath = Path.Combine(RootPath, "images/");

            if (Directory.Exists(fullImagePath))
            {
                byte[] bytes = Convert.FromBase64String(country.Flag);
                var memoryStream = new MemoryStream(bytes);

                var image = Image.FromStream(memoryStream);
                string filename = fullImagePath + country.Name + ".png";
                image.Save(filename, format: System.Drawing.Imaging.ImageFormat.Png);
            }

            await File.WriteAllTextAsync(fullPath, string.Empty);

            await File.WriteAllTextAsync(fullPath, newCountryAddedToList);

        }

        public async Task<List<string>> GetContinents()
        {
            var countryList = await GetCountriesListAsync();

            return countryList.Countries.Select(x => x.Continent).Distinct().ToList();
        }

        public async Task<CountryData> GetCountriesListAsync()
        {
            var getCountryList = new CountryData();
            var countries = new List<Country>();

            var getCountryListAsync = _GetCountryListData();

            foreach (var country in getCountryListAsync.Countries)
            {
                var countryData = new Country
                {
                    Name = country.Name,
                    Continent = country.Continent,
                    Flag = _GetBase64String(country.Flag.Substring(7)),
                    Rank = country.Rank
                };
                countries.Add(countryData);
            }

            getCountryList.Countries = countries;

            return getCountryList;
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            var countryList = await GetCountriesListAsync();

            var getCountry = countryList?.Countries?.Where(x => x.Rank == countryId).FirstOrDefault();

            return new Country
            {
                Name = getCountry?.Name,
                Continent = getCountry?.Continent,
                Flag = getCountry?.Flag,
                Rank = getCountry.Rank
            };
        }


        #region Private Methods
        private CountryData _GetCountryListData()
        {
            return JsonConvert.DeserializeObject<CountryData>(File.ReadAllText("data/data.json"));
        }

        private string _GetBase64String(string? flag)
        {
            return "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes("images/" + flag));
        }

        #endregion


    }
}
