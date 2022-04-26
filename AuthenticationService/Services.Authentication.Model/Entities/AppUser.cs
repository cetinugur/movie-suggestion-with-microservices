using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Services.Authentication.Model.Entities;

public class AppUser : IdentityUser<int>
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedTime { get; set; }
}