﻿using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    public class ServiceLocation
    {
        [Required]
        public string LocationId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        public Service Service { get; set; }

        [Required]
        [StringLength(DataConstants.ServiceLocationCountryMnimumLength, MinimumLength = DataConstants.ServiceLocationCountryMnimumLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(DataConstants.ServiceLocationCityMaximumLength, MinimumLength = DataConstants.ServiceLocationCityMnimumLength)]
        public string City { get; set; }

        [StringLength(DataConstants.ServiceLocationStreetMaximumLength)]
        public string Street { get; set; }

        [StringLength(DataConstants.ServiceLocationAddressMaximumLength)]
        public string Address { get; set; }

        [StringLength(DataConstants.ServiceLocationPostCodeMaximumLength)]
        [RegularExpression("[0-9]{10}")]
        public string PostCode { get; set; }
    }
}