using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// ServicePicture Data Model
    /// </summary>
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

        public bool IsMainPicture { get; set; } = false;
    }
}
