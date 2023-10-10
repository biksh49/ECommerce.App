using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
	public class User
	{
        [Required]
		public string Name { get; set; }
		public int ID { get; set; }
		public string Email { get; set; }
        public string  ContactNumber{ get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Password { get; set; }
    }
}

