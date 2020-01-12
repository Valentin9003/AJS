using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// JobDescription Data Model
    /// </summary>
   public class JobDescription
    {
        [Required]
        public string DescriptionId { get; set; }

        [Required]
        [StringLength(DataConstants.JobDescriptionTextMaximumLength, MinimumLength = DataConstants.JobDescriptionTextMnimumLength)] // TODO: Add Multilingual Error Message
        public string Description { get; set; }

        [Required]
        public string JobId { get; set; }

        public Job Job { get; set; }
    }
}
