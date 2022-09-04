using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Mvc_WwwLogin.Pages;

namespace Console_UsersDbApplication.Pages
{
    /// <summary>
    /// Семантика функции передачи сообщений на экран 
    /// </summary>
    public interface INotification
    {
        protected void LogInformation(string message);
        protected void LogWarning(string message);

    }




    /// <summary>
    /// Модуль аутентификации для динамического встраивания объектов
    /// </summary>
    public class InjectedLoginModel : AbstractLoginModel<WebUser>
    {
        public InjectedLoginModel(
            ILogger<PageModel<ILogin<WebUser>>> Logger, 
            IServiceProvider Provider, 
            ILogin<WebUser> Service) 

            : base(Logger, Provider, Service)
        {
        }

        public override Task<MethodResult<WebUser>> PasswordSignInAsync(string email, string password, bool rememberMe)
            => Service.PasswordSignInAsync(email, password, rememberMe);



        public override Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
               => Service.GetExternalAuthenticationSchemesAsync(   );


        protected override void LogWarning(string v)
        {
            throw new NotImplementedException();
        }

        protected override void LogInformation(string v)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class FileLoginModel : AbstractLoginModel<WebUser>
    {
        public FileLoginModel(
            ILogger<PageModel<ILogin<WebUser>>> Logger, 
            IServiceProvider Provider, 
            ILogin<WebUser> Service)
            : base(Logger, Provider, Service)
        {
        }

        public override Task<MethodResult<WebUser>> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        protected override void LogWarning(string message)
        {
            Console.WriteLine(message);
        }

        protected override void LogInformation(string message)
        {
            Console.WriteLine(message);

        }

        public override async Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            await Task.CompletedTask;

            return new List<AuthenticationScheme>()
            {
                new AuthenticationScheme("Basic","Basic-Authentication",typeof(BasicAuthenticationHandler))
                {
                },
                new AuthenticationScheme("OpenID","OpenID",typeof(OpenIDAuthenticationHandler))
                {
                },
                new AuthenticationScheme("OAuth","OAuth",typeof(OAuthAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Jwt-Bearer","Jwt-Bearer",typeof(BasicAuthenticationHandler))
                {
                },



                new AuthenticationScheme("Facebook","Facebook",typeof(FacebookAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Flickr","Flickr",typeof(FlickrAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Github","Github",typeof(GithubAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Google","Google",typeof(GoogleAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Instagram","Instagram",typeof(InstagramAuthenticationHandler))
                {
                },
                new AuthenticationScheme("LinkedIn","LinkedIn",typeof(LinkedInAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Microsoft","Microsoft",typeof(MicrosoftcAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Pinterest","Pinterest",typeof(PinterestAuthenticationHandler))
                {
                },
                new AuthenticationScheme("SoundCloud","SoundCloud",typeof(SoundCloudAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Reddit","Reddit",typeof(RedditAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Tumblr","Tumblr",typeof(TumblrAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Twitter","Twitter",typeof(TwitterAuthenticationHandler))
                {
                },
                new AuthenticationScheme("VK","VK",typeof(VKAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Vimeo","Vimeo",typeof(VimeoAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Yahoo","Yahoo",typeof(YahooAuthenticationHandler))
                {
                },
                new AuthenticationScheme("Карман","Карман",typeof(КарманAuthenticationHandler))
                {
                }



















            };
        }
    }
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
