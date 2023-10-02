using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class tblUser
    {
        

        public int Id { get; set; }

        //[Required(ErrorMessage = "Name is required.")]
        //[StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Address is required.")]
        //[StringLength(50, ErrorMessage = "Address cannot exceed 50 characters.")]
        public string Address { get; set; }

        //[Required(ErrorMessage = "Email is required.")]
        //[StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        //[EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        //[StringLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        public string Password { get; set; }

        public int? ContactNumber { get; set; }

        public int? Age { get; set; }

        //[Required(ErrorMessage = "Date of Birth is required.")]
        //[StringLength(50, ErrorMessage = "Date of Birth cannot exceed 50 characters.")]
        public string DOB { get; set; }
    }
}
