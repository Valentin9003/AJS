using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AJS.Web.Models
{
    public class CategoriesNavigationMenuPartialViewModel
    {
        public string ParentCategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Controller { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public List<CategoriesNavigationMenuPartialViewModel> SubCategories { get; set; }
    }
}
