using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    public class AdPicture
    {
        [Required]
        public string PictureId { get; set; } 

        [Required]
        public string AdId { get; set; }

        public Ad Ad { get; set; }

        [Required]
        [MaxLength(DataConstants.AdPictureByteArrayMaximumLength)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];

        public bool IsProfilePicture { get; set; } = false;
    }
}
