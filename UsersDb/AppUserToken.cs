using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

public class AppUserToken : IdentityUserToken<OpenID>
{
    [Key]
    public int ID { get; set; }
    public override OpenID UserId { get; set; }
    public override string LoginProvider { get; set; }
    public override string Name { get; set; }
    public override string Value { get; set; }
}
