using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Jobs Categories
    /// </summary>
    class JobCategory
    {
        public string Name { get; set; } // Primary Key
        public string Description { get; set; }
        public string ParentCategoryId { get; set; } // Foreign Key for Parent Category

        public JobCategory ParentCategory { get; set; }

        public List<JobCategory> Categories = new List<JobCategory>();
    }
}
