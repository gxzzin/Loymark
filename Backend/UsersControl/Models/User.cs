using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersControl.Models
{
    [Table(name: "Users", Schema = "UC")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [RegularExpression(@"[a-zñáéíóúüA-ZÁÉÍÓÚÜñÑ\s]{1,}", ErrorMessage = "{0} only allows letters and spaces!")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [RegularExpression(@"[a-zñáéíóúüA-ZÁÉÍÓÚÜñÑ\s]{1,}", ErrorMessage = "{0} only allows letters and spaces!")]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Display(Name = "Telephone")]
        [Range(1, int.MaxValue)]
        public int? TelephoneNumber { get; set; }


        [Required]
        [Display(Name = "Residence Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Please selected a country.")]
        public int CountryId { get; set; }


        [Required]
        [Display(Name = "Would you like to receive Information?")]
        public bool SendNews { get; set; }


        public virtual Country Country { get; set; }


        public virtual ICollection<Activity> Activities { get; set; }


        public User()
        {
            this.Activities = new HashSet<Activity>();
        }

    }
}
