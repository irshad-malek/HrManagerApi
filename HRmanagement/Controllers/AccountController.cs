using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase

    {
        private readonly HrManagerContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogin _login;

        public AccountController(HrManagerContext context, IConfiguration configuration, ILogin login)
        {
            _context = context;
            _configuration = configuration;
            _login= login;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginVm loginVm)
        {
            if (loginVm is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            bool result = false;
            result = _context.Logins.Where(x => x.Emp.EmailId == loginVm.EmailId && x.Password ==loginVm.Password).Any();
            if (result)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"], audience: _configuration["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            else
            {
                return Unauthorized();

            }
        }
        [HttpPost]
        [Route("createPassword")]
        public async Task<ActionResult<Common<int>>> createPassword(LoginVm loginVm)
        {
            try
            {

                await _login.createPassword(loginVm);
                return Ok(new Common<IEnumerable<LoginVm>>
                {
                    Success = true,
                    Message = "data saved succcessfully",
                });


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
    }
}
