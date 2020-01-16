using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// JobPrice Data Model
    /// </summary>
    public class JobPrice
    {
        public string JobPriceId { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression(DataConstants.JobPriceCurrencyRegex)]
        public string Currency { get; set; }

        public string JobId { get; set; }

        public Job Job { get; set; }
    }
}
