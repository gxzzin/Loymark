using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UsersControlWebApp.ViewModels.Activities;
using UsersControlWebApp.ViewModels.Users;

namespace UsersControlWebApp.Pages
{
    public class IndexActivityModel : PageModel
    {
        private readonly ILogger<IndexActivityModel> _logger;

        public UserReadViewModel UserReadViewModel { get; set; }

        public SearchActivityViewModel SearchActivityViewModel { get; set; }

        public IndexActivityModel(ILogger<IndexActivityModel> logger)
        {
            _logger = logger;
            UserReadViewModel = new UserReadViewModel();
            SearchActivityViewModel = new SearchActivityViewModel();
        }

        public void OnGet(int? id)
        {
            ViewData["JsonData"] = JsonConvert.SerializeObject(new { userId = id });
        }
    }
}
