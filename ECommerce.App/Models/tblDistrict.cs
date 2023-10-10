using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class tblDistrict
    {


        [Key] // This specifies that DistrictID is the primary key.
        public int DistrictID { get; set; }

        [Required(ErrorMessage = "DistrictName is required")]
        [StringLength(50, ErrorMessage = "DistrictName must be at most 50 characters long")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "StateID is required")]
        [ForeignKey("State")]
        public int StateID { get; set; }

        public tblState State { get; set; } // Navigation property for the foreign key relationship
    }
}
