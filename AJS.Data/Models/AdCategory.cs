using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ads Categories
    /// </summary>
    public class AdCategory
    {
      // [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; }

        public string ParentAdCategoryId { get; set; }

      [ForeignKey("ParentAdCategoryId")]
       public AdCategory ParentAdCategory { get; set; }

        public HashSet<AdCategory> Categories { get; set; } = new HashSet<AdCategory>();

        public List<Ad> Ads { get; set; } = new List<Ad>();
   }
}
