using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

public class AppUserRole : IdentityUserRole<OpenID>
{
    [Key]
    public int ID { get; set; }
    public override OpenID UserId { get; set; }
    public override OpenID RoleId { get; set; }


}
