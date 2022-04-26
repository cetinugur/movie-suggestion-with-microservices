using Services.Email.Data;
using Services.Email.Model;
using Services.Email.Repositories.Interfaces;
using Services.Shared.Data.Repository;

namespace Services.Email.Repositories.Repositories
{
    public class EmailRepository : Repository<MovieSuggestion>, IEmailRepository
    {
        public EmailRepository(EmailDbContext context) : base(context)
        {

        }

        public bool CreateEmail(int userId, DateTime requestDateTime)
        {
            return true;
        }
    }
}
