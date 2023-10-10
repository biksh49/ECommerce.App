using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class District
    {


        //[Key] // This specifies that DistrictID is the primary key.
        public int DistrictID { get; set; }

      
        public string DistrictName { get; set; }

    
        public int StateID { get; set; }


        //public State State { get; set; } // Navigation property for the foreign key relationship
    }
}
