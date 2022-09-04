using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mvc_LoginViews.Pages
{
    public interface IActionRequest{

        public string SerialKey { get; set; }
        public string RTquestToken { get; set; }
        public string ServiceType { get; set; }
        public string ActionName { get; set; }
        public IDictionary<string, object> InvokeArgs { get; set; }
 
        
    }


    public class AuthModel : PageModel<IAuthenticationService>, IAuthenticationService
    {
        public AuthenticationProperties AuthenticationProperties { get; }

        public AuthModel(
            ILogger<PageModel<IAuthenticationService>> logger,
            IServiceProvider serviceProvider,            
            IAuthenticationService authenticationService, 
            AuthenticationProperties authenticationProperties):base(logger, serviceProvider, authenticationService)
        {
            AuthenticationProperties = authenticationProperties;
        }

        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
            => this.Service.AuthenticateAsync(context, scheme);
        public Task ChallengeAsync(HttpContext context, string scheme, AuthenticationProperties properties)        
            => this.Service.ChallengeAsync(context, scheme, properties);        
        public Task ForbidAsync(HttpContext context, string scheme, AuthenticationProperties properties)        
            => this.Service.ForbidAsync(context, scheme, properties);        
        public Task SignInAsync(HttpContext context, string scheme, ClaimsPrincipal principal, AuthenticationProperties properties)        
            => this.Service.SignInAsync(context, scheme, principal, properties);        
        public Task SignOutAsync(HttpContext context, string scheme, AuthenticationProperties properties)        
            => this.Service.SignOutAsync(context, scheme, properties);        
    }
}
