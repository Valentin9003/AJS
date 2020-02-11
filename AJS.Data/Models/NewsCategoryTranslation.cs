using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// News Category Translations
    /// </summary>
    public class NewsCategoryTranslation
    {
        [Required]
        public string NewsCategoryTranslationId { get; set; }

        [Required]
        public string Translation { get; set; }

        public NewsCategoryLanguage Language { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public AdCategory Category { get; set; }
    }
}
