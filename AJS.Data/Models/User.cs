using AJS.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AJS.Data.Models
{
    /// <summary>
    /// User Data Model
    /// </summary>
    public class User: IdentityUser
    {
        public UserType UserType { get; set; }

        public ICollection<Ad> Ads { get; set; } = new List<Ad>(); 

        public ICollection<Service> Services { get; set; } = new List<Service>();

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
