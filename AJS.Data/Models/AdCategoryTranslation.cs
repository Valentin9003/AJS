using AJS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ad Category Translations
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
