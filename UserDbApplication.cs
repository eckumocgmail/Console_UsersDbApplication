
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

using System;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
 
using Microsoft.AspNetCore.Authentication;



 


/// <summary>
/// 
/// </summary>
public class UserDbApplication  
{
    public static void Test()
    {
        var db = new UsersDbContext();
        foreach(var r in db.GetRoleNames())
        {
            Console.WriteLine(r);

        }
    }
    public static void Main()
    {
        Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<UserDbApplication>()).Build().Run();

    }

    public void ConfigureDevelopment(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
        app.Run((http) => {
            return Task.Run(() => { 
                Console.WriteLine($"{http.Connection.RemoteIpAddress}:{ http.Connection.RemotePort }");
                
                
            });
        });
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<UsersDbContext>(options =>
                    options.UseSqlite("DataSource=app.db;Cache=Shared"));
        services.AddIdentity<AppUser, AppRole>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UsersDbContext>();
        services.AddRazorPages();
        services.AddScoped(typeof(UserManager<IdentityUser>),sp => null);
    }

    public static void ConfigureUsersServices(IServiceCollection services, IConfiguration config)
    {

    }
    public void PrintUserTokens()
    {
        Console.WriteLine("Tokens: ");
        using(var db = new UsersDbContext())
        {
            foreach(var token in db.UserTokens )
            {
                var user = db.Users.Find(token.UserId);
                string provider = token.LoginProvider;
                string name = token.Name;
                string value = token.Value;
                string username = user.UserName;
                object data = new
                {
                    username = username,
                    provider = provider,
                    token = name,
                    code = value

                };
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
}
