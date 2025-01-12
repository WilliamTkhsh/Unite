using Unite.WebApi.Application.Requests;

namespace Unite.WebApi.Application.Services.Token
{
    public interface ITokenService
    {
        Task<string> GenerateToken(LoginRequest user);
    }
}
