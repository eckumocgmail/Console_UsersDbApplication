using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

public class AppRoleClaim : IdentityRoleClaim<OpenID>
{
    [Key]
    public override int Id { get; set; }
    
    public override OpenID RoleId { get; set; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }

   

    public override void InitializeFromClaim(Claim other)
    {
        base.InitializeFromClaim(other);
    }

    public override Claim ToClaim()
    {
        return base.ToClaim();
    }

     
}
