using Microsoft.AspNetCore.Identity;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public class AppUser : IdentityUser<OpenID>, IActiveObject
{
    [Key]
    public int AppUserID { get; set; }

    [PersonalData]
    public override OpenID Id { get; set; }

    [ProtectedPersonalData]
    public override string UserName { get; set; }
    public override string NormalizedUserName { get; set; }

    [ProtectedPersonalData]
    [DisplayName("Электронная почта 'Достоверна'")]
    public override string Email { get; set; }
    public override string NormalizedEmail { get; set; }

    [DisplayName("Электронная почта 'Достоверна'")]
    [PersonalData]
    public override bool EmailConfirmed { get; set; }

    [DisplayName("Электронная почта 'Достоверна'")]
    public override string PasswordHash { get; set; }

    [DisplayName("Электронная почта 'Достоверна'")]
    public override string SecurityStamp { get; set; }
    public override string ConcurrencyStamp { get; set; }

    [ProtectedPersonalData]
    public override string PhoneNumber { get; set; }

    [PersonalData]
    public override bool PhoneNumberConfirmed { get; set; }

    [PersonalData]    
    public override bool TwoFactorEnabled { get; set; }
    public override DateTimeOffset? LockoutEnd { get; set; }
    public override bool LockoutEnabled { get; set; }
    public override int AccessFailedCount { get; set; }
}