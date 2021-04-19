﻿using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
    }
}