using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class AppUserLogin : IdentityUserLogin<OpenID>
{
    [Key]
    public int Id { get; set; }

    public override string LoginProvider { get; set; }
    public override string ProviderKey { get; set; }
    public override string ProviderDisplayName { get; set; }
    public override OpenID UserId { get; set; }
}
