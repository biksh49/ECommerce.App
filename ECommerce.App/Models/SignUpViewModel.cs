using ECommerce.App.Models;
using System.ComponentModel.DataAnnotations;
 using System.Collections.Generic;

namespace ECommerce.App.Models
    {
        public class SignUpViewModel
        {
        // The properties in this class are often used to capture user
        // input when a new user is signing up or registering on a website or
        // application. It may also include validation attributes to enforce data
        // integrity.
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be at most 50 characters long")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid contact number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Postcode { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password must be at least {2} and at most {1} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Dropdowns for State, District, and City selection
        [Display(Name = "Select State")]
        [Required(ErrorMessage = "Please select a state")]
        public int SelectedStateID { get; set; }
        public IEnumerable<tblState> States { get; set; }

        [Display(Name = "Select District")]
        [Required(ErrorMessage = "Please select a district")]
        public int SelectedDistrictID { get; set; }
        public IEnumerable<tblDistrict> Districts { get; set; }

        [Display(Name = "Select City")]
        [Required(ErrorMessage = "Please select a city")]
        public int SelectedCityID { get; set; }
        public IEnumerable<tblCity> Cities { get; set; }
    }
    }







    
