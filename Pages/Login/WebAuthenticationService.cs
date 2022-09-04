using Microsoft.AspNetCore.Authentication;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// 
/// </summary>
public class WebAuthenticationService<TService, THandler>  
    where THandler : Microsoft.AspNetCore.Authentication.IAuthenticationHandler
    where TService: IAuthenticationService
{
    public string Name { get; set; }
    public string Url { get; set; }
    public WebAuthenticationService( )  
    {
        
    }
}

