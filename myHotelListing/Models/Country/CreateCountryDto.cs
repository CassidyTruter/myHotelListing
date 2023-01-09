using System.ComponentModel.DataAnnotations;

namespace myHotelListing.Models.Country
{
    public class CreateCountryDto // data transfer object (DTO) handles Country post requests
    {
        // fields that aren't specified here get ignored
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
