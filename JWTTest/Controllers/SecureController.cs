using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTTest.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SecureController : ControllerBase
    {
        [HttpGet("GetSecretData")]
        public IActionResult GetSecretData()
        {
            return Ok("This is some secret data!");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("test AllowAnonymous!");
        }
    }
}
