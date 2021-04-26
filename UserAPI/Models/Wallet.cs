using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Wallet
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string CurrencyID { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}