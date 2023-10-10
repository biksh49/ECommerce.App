using ECommerce.App.Models;

namespace ECommerce.App.Models
{
    public class SignUpViewModel
    {
        public IEnumerable<State> State { get; set; }
        public  IEnumerable<District> District { get; set; }
       
    }
}

