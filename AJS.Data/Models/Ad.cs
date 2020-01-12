using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ad Data Model
    /// </summary>
    public class Ad
    {
        [Required]
        public string AdId { get; set; }

        [Required]
        [StringLength(DataConstants.AdTitleMaximumLength, MinimumLength = DataConstants.AdTitleMinimumLength)] // TODO: Add Multilingual Error Message
        public string Title { get; set; }

        [Required]
        public string CreatorId { get; set; } 

        public User Creator { get; set; }

        [Required]
        public string CategoryId { get; set; } 

        public AdCategory Category { get; set; }
        
        public List<AdPicture> Pictures { get; set; } = new List<AdPicture>();

        [Required]
        public string LocationId { get; set; }

        public AdLocation Location { get; set; }

        [Required]
        public string DescriptionId { get; set; }

        public AdDescription Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public AdLanguage Language { get; set; }
    }
}
