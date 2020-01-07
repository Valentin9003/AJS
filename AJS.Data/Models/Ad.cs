using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Full Information About the Add
    /// </summary>
    public class Ad
    {
        [Key]
        [Required]
        public string AdId { get; set; } // Primary Key

        [Required]
        [StringLength(DataConstants.AdNameMaximumLength, MinimumLength = DataConstants.AdNameMinimumLength)] // TODO: Add Multilingual Error Message
        public string Name { get; set; }

        public string CreatorId { get; set; } // Foreign Key for User

        [Required]
        [ForeignKey("Id")]
        public User Creator { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; } // Foreign Key for Category

        public AdCategory Category { get; set; }
        
        [Required]
        [ForeignKey("PictureId")]
        public string MainPictureId { get; set; }

        public AdPicture MainPicture { get; set; }

        public List<AdPicture> Pictures { get; set; } = new List<AdPicture>();

        [Required]
        [ForeignKey("LocationId")]
        public string LocationId { get; set; }

        public AdLocation Location { get; set; }

        [Required]
        [ForeignKey("DescriptionId")]
        public string DescriptionId { get; set; }

        public AdDescription Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public AdLanguage Language { get; set; }
    }
}