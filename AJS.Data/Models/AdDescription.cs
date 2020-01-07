using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// Description of the Ad
    /// </summary>
    public class AdDescription
    {
        [Key]
        [Required]
        public string DescriptionId { get; set; }

        [Required]
        [StringLength(DataConstants.DescriptionTextMaximumLength,MinimumLength = DataConstants.DescriptionTextMnimumLength)] // TODO: Add Multilingual Error Message
        public string Description {get;set;}

        public AdState State { get; set; }

        [Required]
        [ForeignKey("AdId")]
        public string AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
