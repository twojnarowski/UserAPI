using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string BoughtCurrencyId { get; set; }
        public decimal BoughtCurrencyQuantity { get; set; }
        public string SoldCurrencyId { get; set; }
        public decimal SoldCurrencyQuantity { get; set; }
    }
}