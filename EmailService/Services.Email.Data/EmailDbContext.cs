using Microsoft.EntityFrameworkCore;
using Services.Email.Model;

namespace Services.Email.Data
{
    public class EmailDbContext : DbContext
    {
        public EmailDbContext(DbContextOptions<EmailDbContext> options)
            : base(options)
        {

        }

        public DbSet<MovieSuggestionEmail> Emails { get; set; }
    }
}
