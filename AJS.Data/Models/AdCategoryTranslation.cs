using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ad Category Translation Data Model
    /// </summary>
    public class AdCategoryTranslation
    {
        [Required]
        public string AdCategoryTranslationId { get; set; }

        [Required]
        public string Translation { get; set; }

        public AdCategoryLanguage Language { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public AdCategory Category { get; set; }
    }
}
