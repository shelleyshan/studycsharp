using Microsoft.AspNetCore.Mvc;

namespace JWTTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            // 验证用户凭据
            if (loginDto.account == "admin" && loginDto.password == "123456")
            {
                User user = new User();
                user.UserName = loginDto.account;
                user.UserPwd = loginDto.password;
                string token = JwtHelper.GenerateJsonWebToken(user);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
