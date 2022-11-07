using Microsoft.AspNetCore.Mvc;
using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.Helper;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration config;
        internal IUserManager userManager;

        public TokenController(IConfiguration config, IUserManager userManager)
        {
            this.config = config;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(string email, string password)
        {
            var result = await userManager.GetByCredentials(email, password);
            if (result == null)
                return Unauthorized();
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }
    }
}
