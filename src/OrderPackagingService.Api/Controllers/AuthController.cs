using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OrderPackagingService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("generate-token")]
        public IActionResult GenerateToken()
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:SigningKey"];
            var expirationInMinutesString = _configuration["Jwt:ExpirationInMinutes"];

            if (string.IsNullOrEmpty(issuer))
                return BadRequest("Necessary JWT config (Issuer) is missing.");

            if (string.IsNullOrEmpty(audience))
                return BadRequest("Necessary JWT config (Audience) is missing.");

            if ( string.IsNullOrEmpty(key))
                return BadRequest("Necessary JWT config (SigningKey) is missing.");

            if (string.IsNullOrEmpty(expirationInMinutesString))
                return BadRequest("Necessary JWT config (ExpirationInMinutes) is missing.");

            if (!int.TryParse(expirationInMinutesString, out var expiresInMinutes))
                return BadRequest("Value 'Jwt:ExpirationInMinutes' is not a valid number.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(expiresInMinutes),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new Dictionary<string, object>
            {
                { "Token", tokenString },
                { "ExpiresAt", token.ValidTo }
            });
        }
    }
}