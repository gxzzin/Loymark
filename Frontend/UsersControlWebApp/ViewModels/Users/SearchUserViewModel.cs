using System.ComponentModel.DataAnnotations;
using UsersControlWebApp.ViewModels.Shared;

namespace UsersControlWebApp.ViewModels.Users
{
    /// <summary>
    /// ViewModel for search user records.
    /// </summary>
    public class SearchUserViewModel : SearchViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public SearchUserViewModel() : base()
        {

        }
    }
}