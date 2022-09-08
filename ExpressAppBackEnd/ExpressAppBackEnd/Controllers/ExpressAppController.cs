using ExpressAppBackEnd.Dtos;
using ExpressAppBackEnd.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpressAppBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExpressAppController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;

        public ExpressAppController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesDetails()
        {
            try
            {
                var getCountriesList = await _countryRepo.GetCountriesListAsync();

                if (getCountriesList == null) NotFound("No list found");

                return Ok(getCountriesList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message);
            }
        }

        [Route("GetCountryByCountryId/{countryId}")]
        [HttpGet]
        public async Task<IActionResult> GetCountryByCountryId([Required] int countryId)
        {
            try
            {
                var getCountry = await _countryRepo.GetCountryById(countryId);

                if (getCountry == null)
                {
                    return NotFound("No country found for this rank");
                }

                return Ok(getCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContinents()
        {
            try
            {
                var getContinents = await _countryRepo.GetContinents();

                if (getContinents == null) NotFound("No continents available");

                return Ok(getContinents);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(Country country)
        {
            try
            {
                var getCountriesList = await _countryRepo.GetCountriesListAsync();

                if (getCountriesList.Countries.Exists(x => x.Name == country.Name))
                {
                    return BadRequest("Country Name already exist");
                }

                if (getCountriesList.Countries.Exists(x => x.Rank == country.Rank))
                {
                    return BadRequest("Rank should be unique");
                }

                await _countryRepo.AddCountry(country);

                return Ok("Successfully Country been Added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message);
            }
        }
    }
}