using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class tblCity
    {
        [Key] // This specifies that CityID is the primary key.
        public int CityID { get; set; }

        [Required(ErrorMessage = "CityName is required")]
        [StringLength(50, ErrorMessage = "CityName must be at most 50 characters long")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "StateID is required")]
        [ForeignKey("State")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "DistrictID is required")]
        [ForeignKey("District")]
        public int DistrictID { get; set; }

        public tblState State { get; set; } // Navigation property for the State foreign key relationship

        public tblDistrict District { get; set; } // Navigation property for the District foreign key relationship


    }
}
