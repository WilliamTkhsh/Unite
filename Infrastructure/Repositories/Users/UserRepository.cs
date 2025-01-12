using Dapper;
using System.Data;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            string sql = @"
                SELECT * FROM Users
                WHERE email = @Email";


            return await _dbConnection.QueryFirstOrDefaultAsync(sql, new { Email = email });
        }
        public async Task<User> InsertUserAsync(string email, string password, string role)
        {
            string sql = @"
                INSERT INTO Users (
                    Id, 
                    Email,
                    Password,
                    Role
                ) VALUES (
                    @Id,
                    @Email,
                    @Password,
                    @Role
                ) RETURNING *;";

            var parameters = new
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                Role = role
            };

            try
            {
                return await _dbConnection.QuerySingleAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
