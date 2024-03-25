using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBackendServices.Helpers;
using MyBackendServices.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        public AccountsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Username == "erick" && loginViewModel.Password == "artech")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginViewModel.Username));

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserWithToken
                {
                    Username = loginViewModel.Username,
                    Password = loginViewModel.Password,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}
