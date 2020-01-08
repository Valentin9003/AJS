﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Jobs Categories
    /// </summary>
   public class JobCategory
    {
        public string Name { get; set; } // Primary Key
        public string Description { get; set; }
        public string ParentCategoryId { get; set; } // Foreign Key for Parent Category

        public JobCategory ParentCategory { get; set; }

        public List<JobCategory> Categories { get; set; } = new List<JobCategory>();

        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
