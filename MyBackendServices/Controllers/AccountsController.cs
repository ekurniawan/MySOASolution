using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBackendServices.Helpers;
using MyBackendServices.ViewModels;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;
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
        private readonly IAccountBLL _accountBLL;

        public AccountsController(IOptions<AppSettings> appSettings, IAccountBLL accountBLL)
        {
            _appSettings = appSettings.Value;
            _accountBLL = accountBLL;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountCreateDTO accountCreateDTO)
        {
            try
            {
                await _accountBLL.Register(accountCreateDTO);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("role")]
        public async Task<IActionResult> AddRole(RoleCreateDTO roleCreateDTO)
        {
            try
            {
                await _accountBLL.AddRole(roleCreateDTO);
                return Ok("Role created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("userrole")]
        public async Task<IActionResult> AddUserToRole(UserRoleDTO userRoleDTO)
        {
            try
            {
                await _accountBLL.AddUserToRole(userRoleDTO);
                return Ok("User added to role successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var accountDto = await _accountBLL.Login(loginDTO);
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, accountDto.Username));
                var roles = await _accountBLL.GetRolesFromUser(accountDto.Username);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

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
                    Username = accountDto.Username,
                    Email = accountDto.Email,
                    PhoneNumber = accountDto.PhoneNumber,
                    Firstname = accountDto.Firstname,
                    Lastname = accountDto.Lastname,
                    Address = accountDto.Address,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
