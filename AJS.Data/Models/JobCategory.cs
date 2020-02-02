using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJS.Data.Models
{
    /// <summary>
    /// JobCategory Data Model
    /// </summary>
    public class JobCategory
    {
        [Required]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentJobCategoryId { get; set; }

        [ForeignKey("ParentJobCategoryId")]
        public JobCategory ParentJobCategory { get; set; }

        public HashSet<JobCategory> Categories { get; set; } = new HashSet<JobCategory>();

        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
