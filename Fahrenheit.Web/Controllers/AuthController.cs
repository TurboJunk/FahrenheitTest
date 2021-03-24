using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.User;
using Fahrenheit.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IRepository db;

        public AuthController(IOptions<AuthOptions> authOptions, IRepository db)
        {
            this.authOptions = authOptions;
            this.db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await AuthenticateUser(login.Name);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(token);
            }

            return Unauthorized();
        }

        private async Task<User> AuthenticateUser(string name)
        {
            return await db.GetUser(name);
        }

        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
