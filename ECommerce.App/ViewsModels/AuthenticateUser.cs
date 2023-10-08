using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.ViewsModels
{
    public class AuthenticateUser
    {
        [Key]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
