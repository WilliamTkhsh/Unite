//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Unite.WebApi.Domain.Entities;
//using Unite.WebApi.Infrastructure.Repositories.Users;

//namespace Unite.WebApi.Application.Services.Token
//{
//    public class TokenService : ITokenService
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IUserRepository _userRepository;

//        public TokenService(IConfiguration configuration, IUserRepository userRepository)
//        {
//            _configuration = configuration;
//            _userRepository = userRepository;
//        }

//        public async Task<string> GenerateToken(User user)
//        {
//            var userDatabase = await _userRepository.GetUserByEmailAsync(user.Email);

//            if (user.Email != userDatabase.Email && user.Password != userDatabase.Password)
//                return string.Empty;

//            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));

//            var issuer = _configuration["Jwt:Issuer"];
//            var audience = _configuration["Jwt:Audience"];

//            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

//            var tokenOptions = new JwtSecurityToken(
//                issuer: issuer,
//                audience: audience,
//                claims: new[]
//                {
//                    new Claim(type: ClaimTypes.Email, user.Email),
//                    new Claim(type: ClaimTypes.Role, user.Role),
//                },
//                expires: DateTime.Now.AddHours(2),
//                signingCredentials: signInCredentials
//            );

//            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

//            return token;
//        }
//    }
//}
