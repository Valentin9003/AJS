using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AJS.Data.Models
{
    /// <summary>
    /// Location of the Ad
    /// </summary>
    public class AdLocation
    {
        public string LocationId { get; set; } // Primary Key

        public string AdId { get; set; } // Foreign Key for Ad

        public Ad Ad { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Address { get; set; }
    }
}
