﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class AuthenticateUser
    {
        
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
