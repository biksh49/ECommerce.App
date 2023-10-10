using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class User
    {

        public int ID { get; set; }

      
        public string Name { get; set; }

        public int? Age { get; set; }

   
        public string Email { get; set; }

     
        public string ContactNumber { get; set; }

       
        public string PostCode { get; set; }

       
        public string Password { get; set; }

        public int? StateID { get; set; }
        public int? DistrictID { get; set; }
        public int? CityID { get; set; }

    }
}
