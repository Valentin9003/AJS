using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Service Data Model
    /// </summary>
    public class Service
    {
        [Required]
        public string ServiceId { get; set; }

        [Required]
        [StringLength(DataConstants.ServiceTitleMaximumLength, MinimumLength = DataConstants.ServiceTitleMinimumLength)] // TODO: Add Multilingual Error Message
        public string Title { get; set; }

        [Required]
        public int ReviewCounter { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public ServiceCategory Category { get; set; }

        public ICollection<ServicePicture> Pictures { get; set; } = new List<ServicePicture>();

        public ServiceLocation Location { get; set; }

        public ServiceDescription Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public ServiceLanguage Language { get; set; }

        public ICollection<ServicePrice> Prices { get; set; } = new List<ServicePrice>();
    }
}
