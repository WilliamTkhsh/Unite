using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        public Task<User> GetUserByEmailAsync(string email);

        public Task<User> InsertUserAsync(string email, string password, string role);
    }
}
