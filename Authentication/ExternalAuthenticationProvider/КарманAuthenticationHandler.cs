using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Mvc_WwwLogin.Pages
{
    public class КарманAuthenticationHandler : IAuthenticationHandler
    {

        protected Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            throw new System.NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            throw new System.NotImplementedException();
        }
    }
}