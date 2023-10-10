using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class City
    {
        //[Key] // This specifies that CityID is the primary key.
        public int CityID { get; set; }

       
        public string CityName { get; set; }

 
        public int StateID { get; set; }

     
        public int DistrictID { get; set; }


    }
}
