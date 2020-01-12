using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    public class ServicePicture
    {
        [Required]
        public string PictureId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        public Service Service { get; set; }

        [Required]
        [MaxLength(DataConstants.ServicePictureByteArrayMaximumLength)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];

        public bool IsProfilePicture { get; set; } = false;
    }
}
