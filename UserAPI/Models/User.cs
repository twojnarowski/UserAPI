using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
    }
}