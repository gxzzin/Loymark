using System;
using System.ComponentModel.DataAnnotations;

namespace UsersControlWebApp.ViewModels.Users
{
    public class CRUDUserViewModel
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Display(Name = "Telephone Number")]
        public int? TelephoneNumber { get; set; }

        [Required]
        [Display(Name = "Would you like to receive information?")]
        public bool SendNews { get; set; }

        [Required]
        [Display(Name = "Residence Country")]
        public int CountryId { get; set; }

    }
}