using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// JobPicture Data Model
    /// </summary>
   public class JobPicture
    {
        [Required]
        public string PictureId { get; set; }

        [Required]
        public string JobId { get; set; }

        public Job Job { get; set; }

        [Required]
        [MaxLength(DataConstants.JobPictureByteArrayMaximumLength)]
        public byte[] PictureByteArray { get; set; } = new byte[(10 * 1024 * 1024)];
    }
}
