using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// NewsCategory Data Model
    /// </summary>
    public class NewsCategory
    {
        [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<News> News { get; set; } = new List<News>();

        public ICollection<NewsCategoryTranslation> Translations { get; set; } = new HashSet<NewsCategoryTranslation>();
    }
}
