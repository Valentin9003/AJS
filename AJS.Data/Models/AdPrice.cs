using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    ///  Ad Price Data Model
    /// </summary>
   public class AdPrice
    {
        public string AdPriceId { get; set; }

        [Range(0.1,double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression(DataConstants.AdPriceCurrencyRegex)]
        public string Currency { get; set; }

        public string AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
