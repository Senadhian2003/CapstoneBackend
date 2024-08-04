using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoffeeStoreManagementApp.Services
{
    public class TokenService : ITokenService
    {

        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(string token)
        {
            //_secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _secretKey = token;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
        public string GenerateToken(User user)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("Id", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }

        public string GenerateEmployeeToken(Employee employee)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("Id", employee.EmployeeId.ToString()),
                new Claim(ClaimTypes.Role, employee.Role.ToString())
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }

    }
}
