using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// News Category Translation Data Model
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

        public NewsCategory Category { get; set; }
    }
}
