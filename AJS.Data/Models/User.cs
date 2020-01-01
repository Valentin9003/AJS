using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.Models
{
   public class User: IdentityUser
    {
        public List<Ad> Ads { get; set; } = new List<Ad>(); // List of created Ads

        // public List<Service> Services { get; set; } = new List<Service> // List of created Services

        // public List<Jobs> Services { get; set; } = new List<Jobs> // List of created Jobs
    }
}
