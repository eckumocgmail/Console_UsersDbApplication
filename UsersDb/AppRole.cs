using Microsoft.AspNetCore.Identity;

using System;
using System.ComponentModel.DataAnnotations;

public class AppRole : IdentityRole<OpenID>
{
    [Key]
    public int AppRoleId { get; set; }
    public override OpenID Id { get; set; }

    [Required]
    [Display(Name = "Наименование")]
    public override string Name { get; set; }

    [Display(Name = "Наименование")]
    public override string NormalizedName { get; set; }

    [Display(Name = "Идентификатор процесса")]
 


    /// <summary>
    /// Случайное значение, должно быть обновлено
    /// каждый раз при сохранении
    /// </summary>
    public override string ConcurrencyStamp { get; set; }
        = Guid.NewGuid().ToString();
     
}


