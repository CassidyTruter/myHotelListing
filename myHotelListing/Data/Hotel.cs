using myHotelListing.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace myHotelListing.API.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } // Type 'prop' then double click on tab to generate this line
        public double Rating { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; } // Press Ctrl+. to get option to generate Country.cs
    }
}
