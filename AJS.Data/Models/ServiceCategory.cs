using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// Services Categories
    /// </summary>
    public class ServiceCategory
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentServiceCategoryId { get; set; }

        [ForeignKey("ParentServiceCategoryId")]
        public ServiceCategory ParentServiceCategory { get; set; }

        public HashSet<ServiceCategory> Categories { get; set; } = new HashSet<ServiceCategory>();

        public List<Service> Services { get; set; } = new List<Service>();
    }
}
