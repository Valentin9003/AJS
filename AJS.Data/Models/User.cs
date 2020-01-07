using AJS.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AJS.Data.Models
{
    public class User: IdentityUser
    {
        public UserType UserType { get; set; }
        public List<Ad> Ads { get; set; } = new List<Ad>(); // List of created Ads

        // public List<Service> Services { get; set; } = new List<Service> // List of created Services

        // public List<Jobs> Services { get; set; } = new List<Jobs> // List of created Jobs
    }
}
