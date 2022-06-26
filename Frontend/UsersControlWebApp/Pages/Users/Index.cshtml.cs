using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UsersControlWebApp.ViewModels.Users;

namespace UsersControlWebApp.Pages
{
    public class IndexUserModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexUserModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            SearchUserViewModel = new SearchUserViewModel();
            CRUDUserViewModel = new CRUDUserViewModel();
        }

        public SearchUserViewModel SearchUserViewModel { get; set; }

        public CRUDUserViewModel CRUDUserViewModel { get; set; }

        public void OnGet()
        {

        }
    }
}
