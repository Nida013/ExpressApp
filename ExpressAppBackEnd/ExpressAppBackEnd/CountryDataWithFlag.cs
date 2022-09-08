using Microsoft.OpenApi.Writers;
using System.ComponentModel.DataAnnotations;

namespace ExpressAppBackEnd
{
    public class CountryDataWithFlag
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value of {0}")]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a value of {0}")]
        public string? Continent { get; set; }

        [Required(AllowEmptyStrings = true,ErrorMessage = "Please enter a value of {0}")]
        public string? Flag { get; set; }

        public int Rank { get; set; }
    }
}
