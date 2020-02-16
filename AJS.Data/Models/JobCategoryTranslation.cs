using AJS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Job Category Translation Data Model
    /// </summary>
    public class JobCategoryTranslation
    {
        [Required]
        public string JobCategoryTranslationId { get; set; }

        [Required]
        public string Translation { get; set; }

        public JobCategoryLanguage Language { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public JobCategory Category { get; set; }
    }
}
