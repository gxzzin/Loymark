using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersControl.Models
{
    [Table(name: "Activities", Schema = "UC")]
    public class Activity
    {
        [Key]
        [Column(name: "Id_Activity")]
        public int Id { get; set; }

        [Display(Name = "Create Date")]
        [Required]
        [Column(name: "Create_Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "User")]
        [Required]   
        [Column(name: "Id_User")]
        public int UserId { get; set; }

        [Display(Name = "Activity Description")]
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        // public virtual User User { get; set; }
    }
}