using Services.Email.Model;
using Services.Shared.Data.Repository;

namespace Services.Email.Repositories.Interfaces
{
    public interface IEmailRepository : IRepository<MovieSuggestionEmail>
    {
    }
}
