using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CurrencyID { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}