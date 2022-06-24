using System;
using System.ComponentModel.DataAnnotations;

namespace UsersControl.DTO
{
    public class UserCreateDTO
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

        public int? TelephoneNumber { get; set; }

        [Display(Name = "Would you like to receive information?")]
        public bool SendNews { get; set; } 

        public int CountryId { get; set; }
    }
}