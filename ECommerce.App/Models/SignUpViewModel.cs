using ECommerce.App.Models;
using System.ComponentModel.DataAnnotations;
 using System.Collections.Generic;

namespace ECommerce.App.Models
    {
        public class SignUpViewModel
        {
        public IEnumerable<State> State { get; set; }
        public IEnumerable<District> District { get; set; }
        public IEnumerable<City> City { get; set; } 


    }
    }







    
