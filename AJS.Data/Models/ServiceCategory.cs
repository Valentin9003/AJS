using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Services Categories
    /// </summary>
    class ServiceCategory
    {
        public string Name { get; set; } // Primary Key
        public string Description { get; set; }
        public string ParentCategoryId { get; set; } // Foreign Key for Parent Category

        public ServiceCategory ParentCategory { get; set; }

        public List<ServiceCategory> Categories { get; set; } = new List<ServiceCategory>();

        public List<Service> Services { get; set; } = new List<Service>();
    }
}
