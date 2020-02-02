using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// ServicePrice Data Model
    /// </summary>
    public class ServicePrice
    {
        public string ServicePriceId { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression(DataConstants.ServicePriceCurrencyRegex)]
        public string Currency { get; set; }

        public string ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
