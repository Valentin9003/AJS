using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AJS.Data.Models
{
   public class AdPicture
    {
        [Key]
        [Required]
        public string Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("AdId")]
        public string AdId { get; set; }

        public Ad Ad { get; set; }

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];  // Max size for Picture is 10MB

        public bool IsProfilePicture { get; set; } = false;
    }
}
