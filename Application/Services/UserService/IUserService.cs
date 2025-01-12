using Microsoft.AspNetCore.Identity.Data;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Application.Services.UserService
{
    public interface IUserService
    {
        public Task<User> AddUser(LoginRequest user);
    }
}
