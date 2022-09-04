using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

public class AppUserClaim : IdentityUserClaim<OpenID>
{
    [Key]
    public override int Id { get; set; }
    public override OpenID UserId { get; set; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }

    public override void InitializeFromClaim(Claim claim)
    {
        base.InitializeFromClaim(claim);
    }

    public override Claim ToClaim()
    {
        return base.ToClaim();
    }
}
