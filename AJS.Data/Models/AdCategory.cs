using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Ads Categories
    /// </summary>
   public class AdCategory
    {
        public string Name { get; set; } // Primary Key
        public string Description { get; set; }
        public string ParentCategoryId { get; set; } // Foreign Key for Parent Category

        public AdCategory ParentCategory { get; set; }

        public List<AdCategory> Categories = new List<AdCategory>();
   }
}
