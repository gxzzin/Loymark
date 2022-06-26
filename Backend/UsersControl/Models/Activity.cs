using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersControl.Models
{
    [Table(name: "Activities", Schema = "UC")]
    public class Activity
    {
        [Key]
        [Column(name: "id_activity")]
        public int Id { get; set; }

        [Display(Name = "Create Date")]
        [Required]
        [Column(name: "create_date")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Activity Type")]
        [Required]
        [StringLength(maximumLength: 3)]
        [Column(name: "activity_type")]
        public string ActivityType { get; set; }


        [Display(Name = "Activity Description")]
        [Required]
        [StringLength(maximumLength: 150)]
        [Column(name: "activity_description")]
        public string ActivityDescription { get; set; }


        [Display(Name = "User")]
        [Required]
        [Column(name: "id_user")]
        public int UserId { get; set; }


        [Display(Name = "User Data")]
        [Required]
        [Column(name: "data_user")]
        public string UserData { get; set; }


        // public virtual User User { get; set; }
    }
}