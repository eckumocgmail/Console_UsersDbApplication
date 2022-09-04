using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Mvc_WwwLogin.Pages
{

    public interface ILogin<TActiveObject> where TActiveObject: IActiveObject
    {
        public Task<MethodResult<TActiveObject>> PasswordSignInAsync(string email, string password, bool rememberMe);
        public Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    }
    /// <summary>
    /// 
    /// </summary>    
    public abstract class AbstractLoginModel<TUser> : PageModel<ILogin<TUser>>, ILogin<TUser> where TUser: IActiveObject
    {
        public AbstractLoginModel(ILogger<PageModel<ILogin<TUser>>> Logger, IServiceProvider Provider, ILogin<TUser> Service) : base(Logger, Provider, Service)
        {
            if (Provider == null)
                throw new ArgumentNullException("Provider");
            foreach (var Property in this.GetType().GetProperties())
            {
                foreach (var Data in Property.GetCustomAttributesData())
                {
                    Console.WriteLine($"{Property.Name} " +
                        $"{Data.AttributeType.Name}=" +
                        $"{""}");
                }
            }
        }

        public abstract Task<MethodResult<TUser>> PasswordSignInAsync(string email, string password, bool rememberMe);
        public abstract Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();



        protected abstract void LogWarning(string v);
        protected abstract void LogInformation(string v);

        [BindProperty]
        public InputModel Input { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public AuthenticationProperties ExternalScheme { get; private set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Электронная почта")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Запомнить меня")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");            
            //await HttpContext.SignOutAsync(ExternalScheme);
            ExternalLogins = (await GetExternalAuthenticationSchemesAsync()).ToList();
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {                
                var result = await PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe );
                if (result.Succeeded)
                {
                    LogInformation("Пользователь авторизован");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    LogWarning("Пользовательский аккаунт заблокирован.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Не корректные данные");
                    return Page();
                }
            }            
            return Page();
        }

    }
}
