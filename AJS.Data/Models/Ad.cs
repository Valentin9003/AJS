using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Full Information About the Add
    /// </summary>
   public class Ad
    {
        [Key]
        public string AdId { get; set; } // Primary Key

        [Required]
        [StringLength(100,MinimumLength = 2)] // TODO: Add Multilingual Error Message
        public string Name { get; set; }

        [Required]
        public string CreatorId { get; set; } // Foreign Key for User

        public User Creator { get; set; }

        [Required]
        public string CategoryId { get; set; } // Foreign Key for Category

        public AdCategory Category { get; set; }

        public AdPicture MainPicture { get; set; } 

        public List<AdPicture> Pictures { get; set;}  = new List<AdPicture>();

        [Required]
        public AdLocation Location { get; set; }

        [Required]
        public AdDescription Description { get; set; }
        
        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public AdLanguage Language { get; set; }
    }
}
