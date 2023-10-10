using System.ComponentModel.DataAnnotations;

namespace ECommerce.App.Models
{
    public class tblState
    {
        [Key] // This specifies that StateID is the primary key.
        public int StateID { get; set; }

        [Required(ErrorMessage = "StateName is required")]
        [StringLength(50, ErrorMessage = "StateName must be at most 50 characters long")]
        public string StateName { get; set; }
    }
}
