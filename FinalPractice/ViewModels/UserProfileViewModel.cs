using System;
using System.ComponentModel.DataAnnotations;

namespace FinalPractice.ViewModels
{
    public class UserProfileViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Address2 { get; set; }

        //[Required]
        //public string City { get; set; }
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        //[Required]
        //public string Country { get; set; }

        public string Logo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
    }
}