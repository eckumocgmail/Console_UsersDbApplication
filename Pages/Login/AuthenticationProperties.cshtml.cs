using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

namespace Mvc_LoginViews.Pages.Authentication
{
    public class AuthenticationPropertiesModel : PageModel
    {

        public Dictionary<string,bool> ExternalAuthProviders { get; set; } = new Dictionary<string, bool>()
        {
            { "Google", false } 
        };
        public AuthenticationPropertiesModel()
        {

        }
        public void OnGet()
        {
            int x = 0;
        }
    }
}
