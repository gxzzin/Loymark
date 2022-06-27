using System;
using System.ComponentModel.DataAnnotations;

namespace UsersControlWebApp.ViewModels.Users
{
    public class UserReadViewModel
    {

        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Birthday { get; set; }

        [Display(Name = "Telephone Number")]
        public int? TelephoneNumber { get; set; }

        [Display(Name = "Receive information?")]
        public bool SendNews { get; set; }

        [Display(Name = "Residence Country")]
        public string CountryNameAndCode { get; set; }

    }
}