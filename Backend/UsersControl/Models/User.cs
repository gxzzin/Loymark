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
        [StringLength(maximumLength: 100)]
        // [RegularExpression(pattern: @"")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        // [RegularExpression(pattern: @"")]|
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        // [RegularExpression(pattern: @"")]|
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Display(Name = "Telephone")]
        public int? TelephoneNumber { get; set; }


        [Display(Name = "Residence Country")]
        [Required]        
        public int CountryId { get; set; }


        [Required]
        [Display(Name = "Would you like to receive Information?")]
        public bool SendNews { get; set; }

        // public virtual ICollection<Activity> Activities { get; set; }


        public User()
        {
            // this.Activities = new HashSet<Activity>();
        }

    }
}
