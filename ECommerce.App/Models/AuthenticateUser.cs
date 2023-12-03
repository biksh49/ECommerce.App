using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class AuthenticateUser
    {
        [Required]
        [StringLength(50,ErrorMessage ="The Email length can be more than 50",MinimumLength=10)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
   
   

}
