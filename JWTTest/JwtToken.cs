using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace JWTTest
{
    public static class JWTHandler
    {
        public static string GenerateJwtToken(string userName, string issuer, string audience, string secretKey, int expirationMinutes = 20)
        {
            // 确保secretKey至少为16字节，如果不足，可以增加长度或使用其他方式生成
            if (secretKey.Length < 16)
            {
                throw new ArgumentException("Secret key must be at least 16 characters long.");
            }
            // 创建签名密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim("ID", "1001"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "超级管理员"));

            // 创建Token
            var token = new JwtSecurityToken(
              TokenParameter.Issuer,
              TokenParameter.Audience,
              claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            // 序列化Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }

    
}