using System;
using System.ComponentModel.DataAnnotations;

namespace UsersControl.DTO
{
    public class UserCreateDTO
    {

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [RegularExpression(@"[a-zñáéíóúüA-ZÁÉÍÓÚÜñÑ\s]{1,}", ErrorMessage = "{0} only allows letters and spaces!")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [RegularExpression(@"[a-zñáéíóúüA-ZÁÉÍÓÚÜñÑ\s]{1,}", ErrorMessage = "{0} only allows letters and spaces!")]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        [DataType(dataType: DataType.EmailAddress)]
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