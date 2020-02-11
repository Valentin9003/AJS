using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// ServicesCategory Data Model
    /// </summary>
    public class ServiceCategory
    {
        [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentServiceCategoryId { get; set; }

        [ForeignKey("ParentServiceCategoryId")]
        public ServiceCategory ParentServiceCategory { get; set; }

        public HashSet<ServiceCategory> Categories { get; set; } = new HashSet<ServiceCategory>();

        public List<Service> Services { get; set; } = new List<Service>();

        public ICollection<ServiceCategoryTranslation> Translations { get; set; } = new HashSet<ServiceCategoryTranslation>();
    }
}
