using System.ComponentModel.DataAnnotations;

namespace UsersControl.DTO
{
    /// <summary>
    /// Data Transfer Objecto to Search Users records.
    /// </summary>
    public class UserSearchDTO : SearchDTO
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public UserSearchDTO() : base()
        {
            
        }
    }
}