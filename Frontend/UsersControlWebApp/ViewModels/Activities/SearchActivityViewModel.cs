using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using UsersControlWebApp.ViewModels.Shared;

namespace UsersControlWebApp.ViewModels.Activities
{
    /// <summary>
    /// ViewModel for search activities records.
    /// </summary>
    public class SearchActivityViewModel : SearchViewModel
    {

        public int? UserId { get; set; }


        [Display(Name = "Activity Type")]
        public string ActivityType { get; set; }


        public IEnumerable<SelectListItem> AvailableActivityTypes { get; set; }


        public SearchActivityViewModel() : base()
        {
            AvailableActivityTypes = new List<SelectListItem>()
            {
                new SelectListItem { Value = "*", Text  = "-- all --" },
                new SelectListItem { Value = "i", Text  = "User Created" },
                new SelectListItem { Value = "u", Text = "User Updated" },
                new SelectListItem { Value = "d", Text = "User Deleted" },
            };
        }

    }
}