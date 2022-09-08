using System.ComponentModel.DataAnnotations;

namespace ExpressAppBackEnd.Dtos
{

    public class CountryData
    {
        public List<Country>? Countries { get; set; }
    }


    public class Country
    {

        [Required(AllowEmptyStrings =false,ErrorMessage = "Please enter a value of {0}")]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value of {0}")]
        public string? Continent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value of {0}")]
        public string? Flag { get; set; }

        public int Rank { get; set; }
    }
}
