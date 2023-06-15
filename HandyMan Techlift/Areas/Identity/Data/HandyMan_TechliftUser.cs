using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandyMan_Techlift.Areas.Identity.Data;

public class HandyMan_TechliftUser:IdentityUser
{
public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
    [NotMapped]
    public string FullName
    {
        get
        {
            return UserFirstName + " " + UserLastName;
        }
    }
}
