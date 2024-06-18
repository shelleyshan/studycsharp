using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTTest
{
    public class JwtHelper
    {
        public static string GenerateJsonWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenParameter.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim("ID", "1001"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userInfo.UserName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "超级管理员"));
            var token = new JwtSecurityToken(TokenParameter.Issuer,
              TokenParameter.Audience,
              claimsIdentity.Claims,
              expires: DateTime.Now.AddMinutes(TokenParameter.AccessExpiration),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class TokenParameter
    {
        public const string Issuer = "lqwvje";//颁发者        
        public const string Audience = "LuoFenMing";//接收者    
        public const string Secret = "1122334455667788dwerwqreqreqreq3rdsafewqreqrfeafdwerqr";//签名秘钥        
        public const int AccessExpiration = 30;//AccessToken过期时间（分钟）
    }
    public class User
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
    }
}