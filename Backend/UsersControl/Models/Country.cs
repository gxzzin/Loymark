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
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "Country Code")]
        [StringLength(maximumLength: 100)]
        public string Alpha3Code { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Country()
        {
            Users = new HashSet<User>();
        }
    }
}