using myHotelListing.API.Data;

namespace myHotelListing.Data
{
    public class Country
    {
        public int Id { get; set; } // When Entity framework sees this model it will know that this
                                    // is an automatically incrementing primary id (same if it was 
                                    // called CountryId)
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}