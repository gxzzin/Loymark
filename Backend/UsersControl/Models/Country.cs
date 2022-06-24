using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersControl.Models
{
    [Table(name: "Countries", Schema = "CM")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        // [RegularExpression(pattern: @"")]
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "Country Code (ISO 3166-1)")]
        [StringLength(maximumLength: 100)]
        public string ISO_3166_1 { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Country()
        {
            Users = new HashSet<User>();
        }
    }
}