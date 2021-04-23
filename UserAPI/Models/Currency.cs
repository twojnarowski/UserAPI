using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Currency
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}