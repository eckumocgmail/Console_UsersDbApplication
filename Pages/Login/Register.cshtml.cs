using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Mvc_WwwLogin.Pages
{

    [AllowAnonymous]
    public class RegisterModel : AbstractRegisterModel<WebUser>
    {
        public override Task SendEmailAsync(string email, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task SignInAsync(string email, string password, bool isPersistent)
        {
            throw new NotImplementedException();
        }

        public override Task<MethodResult<WebUser>> CreateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
