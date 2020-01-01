using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AJS.Data.Models
{
   public class AdPicture
    {
        public string PictureId { get; set; } // Primary Key

        [Required]
        [MaxLength(10 * 1024 * 1024)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];  // Max size for Picture is 10MB

        public bool IsProfilePicture { get; set; } = false;
    }
}
