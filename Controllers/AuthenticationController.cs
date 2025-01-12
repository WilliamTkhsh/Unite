//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using Unite.WebApi.Application.Services.Token;

//namespace Unite.WebApi.Controllers
//{
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly ITokenService _tokenService;

//        public AuthenticationController(ITokenService tokenService)
//        {
//            _tokenService = tokenService;
//        }

//        [HttpPost("login", Name = "login")]
//        public async Task<IActionResult> Login(LoginRequest loginRequest)
//        {
//            var token = await _tokenService.GenerateToken(loginRequest);

//            if (token == "")
//                return Unauthorized();
//        }

//        [HttpPost("sign-in", Name = "sign-in")]
//        public async Task<IActionResult> SignIn(Microsoft.AspNetCore.Identity.loginRequest)
//        {
//            var token = await _tokenService.GenerateToken(loginRequest);

//            if (token == "")
//                return Unauthorized();
//        }
//    }
//}
