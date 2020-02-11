using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Job Category Translations
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
