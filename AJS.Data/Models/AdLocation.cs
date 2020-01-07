
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// Location of the Ad
    /// </summary>
    public class AdLocation
    {
        [Key]
        [Required]
        public string LocationId { get; set; }

        [Required]
        [ForeignKey("AdId")]
        public string AdId { get; set; }

        public Ad Ad { get; set; }

        [Required]
        [StringLength(DataConstants.AdLocationCountryMnimumLength, MinimumLength = DataConstants.AdLocationCountryMnimumLength)]
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
