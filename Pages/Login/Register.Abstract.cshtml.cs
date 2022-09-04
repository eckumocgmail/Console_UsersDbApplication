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
    public abstract class AbstractRegisterModel<TUser> : PageModel
    {

        public abstract Task SendEmailAsync(string email, string v1, string v2);


        public abstract Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        public abstract Task SignInAsync(string email, string password, bool isPersistent);
        public abstract Task<MethodResult<TUser>> CreateUserAsync(string email, string password);
        public abstract Task<string> GenerateEmailConfirmationTokenAsync(string username, string password);
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public bool IsConfirmedAccountRequire { get; private set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            { 
                var result = await CreateUserAsync(Input.Email, Input.Password);
                if (result.Succeeded)
                {

                    var code = await GenerateEmailConfirmationTokenAsync(Input.Email, Input.Password);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity",  Input.Email, code, returnUrl },
                        protocol: Request.Scheme);

                    await SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (IsConfirmedAccountRequire)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                    }
                    else
                    {
                        await SignInAsync(Input.Email, Input.Password, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        
    }
}
