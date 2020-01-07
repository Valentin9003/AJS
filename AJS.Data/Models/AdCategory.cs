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
       [Key]
       [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; }

        [ForeignKey("Id")]
        public string ParentCategoryId { get; set; }

        public AdCategory ParentCategory { get; set; }

        public List<AdCategory> Categories { get; set; } = new List<AdCategory>();

        public List<Ad> Ads { get; set; } = new List<Ad>();
   }
}
