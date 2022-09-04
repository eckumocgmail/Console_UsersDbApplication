using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


public interface IUsers
{
    public IEnumerable<string> GetRoleNames();
    public string Signin(string login, string password);
    public bool CreateLogin(string login, string password);
    public IEnumerable<string> GetLogins(params string[] Roles);
    public void CreateRole(string name);
    public bool ExistsRole(string name);
    
}



public class ApplicationProvider: IServiceProvider
{
    public object GetService(Type serviceType)
    {
        var contructor = serviceType.GetConstructors().First();
        
        return serviceType.GetConstructors().First().Invoke(contructor.GetParameters().Select(p => GetService(p.ParameterType)).ToArray());
    }
    static ApplicationProvider INSTANCE;
    internal static IServiceProvider Get() =>
        INSTANCE == null ? (INSTANCE = new ApplicationProvider()) : INSTANCE;
}
public class SearchDbContext : UsersDbContext, IDbContextOptionsExtension
{
    public SearchDbContext(string filename) : base(filename)
    {
    }

    public void ApplyServices(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    public void Validate(IDbContextOptions options)
    {
        throw new NotImplementedException();
    }

    public DbContextOptionsExtensionInfo Info => throw new NotImplementedException();
}




/// <summary>
/// 
/// </summary>
public class UsersDbContext: 
    IdentityDbContext<AppUser, AppRole, OpenID, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>, 
    IUsers,
    IServiceProvider
{
    private static ILogger<UsersDbContext> logger = LoggerFactory.Create(options=>options.AddConsole()).CreateLogger<UsersDbContext>();
    public static IConfiguration configuration = null;

    [Required]
    private readonly string filename;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="services"></param>
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        logger.LogInformation("ConfigureServices()");
        services.AddDbContext<UsersDbContext>(ConfigureDbContextCallback( ));
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Action<DbContextOptionsBuilder> ConfigureDbContextCallback()
    {
        logger.LogInformation("ConfigureDbContextCallback()");
        
        
        return (options) => {
            options.UseApplicationServiceProvider(ApplicationProvider.Get());
            options.UseInternalServiceProvider(ApplicationProvider.Get());
            options.AddInterceptors(ApplicationProvider.Get().GetServices<IInterceptor>());
            options.UseSqlite($"DataSource=users.db");
        };
    }

    public static void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        logger.LogInformation("ConfigureDbContext()");
        if (builder.IsConfigured == false)
        {
    
            builder.UseSqlite("DataSource=users.db;Cache=Shared");
        }
    }

    public static void ModelCreate(ModelBuilder builder)
    {
        logger.LogInformation("ModelCreate()");

    }


    public UsersDbContext() : this("users.db") { }
    public UsersDbContext(string filename)
    {
        this.filename = filename;
        this.OnInit();

    }

    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
        this.OnInit();        
    }

    

    protected override void OnModelCreating(ModelBuilder builder)
        => ModelCreate(builder);

    

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
        => ConfigureDbContext(builder);

    private void OnInit()
    {

        //this.Roles
        //this.RoleClaims
        //this.UserClaims
        //this.UserLogins
        //this.UserRoles
        //this.Users
        //this.UserTokens
    }

    public IEnumerable<string> GetRoleNames()
    {
        throw new NotImplementedException();
    }

    public string Signin(string login, string password)
    {
        throw new NotImplementedException();
    }

    public bool CreateLogin(string login, string password)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetLogins(params string[] Roles)
    {
        throw new NotImplementedException();
    }

    public void CreateRole(string name)
    {
        throw new NotImplementedException();
    }

    public bool ExistsRole(string name)
    {
        throw new NotImplementedException();
    }

    public object GetService(Type serviceType)
    {
        Console.WriteLine(serviceType.FullName);
        return ApplicationProvider.Get().GetService(serviceType);
    }
}