using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class tblUser
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

        // Navigation properties for relationships with State, District, and City entities
        public tblState State { get; set; }
        public tblDistrict District { get; set; }
        public tblCity City { get; set; }
        //If your application does not require accessing related entities from a tblUser object directly, you may omit the navigation properties to simplify the class

    }
}
