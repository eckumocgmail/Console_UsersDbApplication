using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using System;


public interface IUser
{
    public void Login();
    public void Login(string username, string password);
    public void Submit(string username, string password);
    public void Logout();
}

public class UserPage : PageModel<IUser>
{
    public UserPage(
        ILogger<PageModel<IUser>> Logger, 
        IServiceProvider Provider, 
        IUser Service) : base(Logger, Provider, Service)
    {
    }
}

public class PageModel<TService>: Microsoft.AspNetCore.Mvc.RazorPages.PageModel
{
    public ILogger<PageModel<TService>> Logger { get; }
    public TService Service { get; }
    public IServiceProvider Provider { get; }


    public PageModel(
        ILogger<PageModel<TService>> Logger, 
        IServiceProvider Provider, 
        TService Service  )
    {
        this.Logger = Logger;
        this.Service = Service;
        this.Provider = Provider;
        this.Logger.LogInformation("Created");
        if(this.Service is OnInit)
        {
            try
            {
                ((OnInit)this.Service).Init(this.Provider, this);
            }
            catch(Exception  )
            {
                this.Logger.LogInformation("Ошибка при инициаллизации "+typeof(TService).Name);
            }
        }

    }
    public interface OnInit { void Init(IServiceProvider ServiceProvider, PageModel<TService> PageModel); }

}
