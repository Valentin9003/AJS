using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// JobLocation Data Model
    /// </summary>
    public class JobLocation
    {
        [Required]
        public string LocationId { get; set; }

        [Required]
        public string JobId { get; set; }

        public Job Job { get; set; }

        [Required]
        [StringLength(DataConstants.JobLocationCountryMaximumLength, MinimumLength = DataConstants.JobLocationCountryMinimumLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(DataConstants.JobLocationCityMaximumLength, MinimumLength = DataConstants.JobLocationCityMinimumLength)]
        public string City { get; set; }

        [StringLength(DataConstants.JobLocationStreetMaximumLength)]
        public string Street { get; set; }

        [StringLength(DataConstants.JobLocationAddressMaximumLength)]
        public string Address { get; set; }

        [StringLength(DataConstants.JobLocationPostCodeMaximumLength)]
        [RegularExpression("[0-9]{10}")]
        public string PostCode { get; set; }
    }
}
