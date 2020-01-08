using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ads Categories
    /// </summary>
    public class AdCategory
    {
       [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; }

        public string ParentAdCategoryId { get; set; }

        public AdCategory ParentAdCategory { get; set; }

        public List<AdCategory> Categories { get; set; } = new List<AdCategory>();

        public List<Ad> Ads { get; set; } = new List<Ad>();
   }
}
