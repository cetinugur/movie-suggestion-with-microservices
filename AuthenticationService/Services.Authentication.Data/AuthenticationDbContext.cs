using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Services.Authentication.Model.Entities;

namespace Services.Authentication.Data
{
    public class AuthenticationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }

    }
}
