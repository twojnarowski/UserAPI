using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int BoughtCurrencyId { get; set; }
        public decimal BoughtCurrencyQuantity { get; set; }
        public int SoldCurrencyId { get; set; }
        public decimal SoldCurrencyQuantity { get; set; }
    }
}