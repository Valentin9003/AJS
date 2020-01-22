using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// AdLocation Data Model
    /// </summary>
    public class AdLocation
    {
        [Required]
        public string LocationId { get; set; }

        [Required]
        public string AdId { get; set; }

        public Ad Ad { get; set; }

        [Required]
        [StringLength(DataConstants.AdLocationCountryMaximumLength, MinimumLength = DataConstants.AdLocationCountryMinmumLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(DataConstants.AdLocationCityMaximumLength, MinimumLength = DataConstants.AdLocationCityMnimumLength)]
        public string City { get; set; }

        [StringLength(DataConstants.AdLocationStreetMaximumLength)]
        public string Street { get; set; }

        [StringLength(DataConstants.AdLocationAddressMaximumLength)]
        public string Address { get; set; }

        [StringLength(DataConstants.AdLocationPostCodeMaximumLength)]
        [RegularExpression("[0-9]{10}")]
        public string PostCode { get; set; }
    }
}
