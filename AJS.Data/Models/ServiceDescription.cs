﻿using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    ///  ServiceDescription Data Model
    /// </summary>
    public class ServiceDescription
    {
        [Required]
        public string DescriptionId { get; set; }

        [Required]
        [StringLength(DataConstants.ServiceDescriptionTextMaximumLength, MinimumLength = DataConstants.ServiceDescriptionTextMinimumLength)] // TODO: Add Multilingual Error Message
        public string Description { get; set; }

        [Required]
        public string ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
