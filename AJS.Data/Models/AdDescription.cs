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
        [Required]
        public string DescriptionId { get; set; }

        [Required]
        [StringLength(DataConstants.AdDescriptionTextMaximumLength, MinimumLength = DataConstants.AdDescriptionTextMnimumLength)] // TODO: Add Multilingual Error Message
        public string Description {get;set;}

        public AdState State { get; set; }

        [Required]
        public string AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
