using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Service Category Translations
    /// </summary>
    public class ServiceCategoryTranslation
    {
        [Required]
        public string ServiceCategoryTranslationId { get; set; }

        [Required]
        public string Translation { get; set; }

        public ServiceCategoryLanguage Language { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public ServiceCategory Category { get; set; }
    }
}
