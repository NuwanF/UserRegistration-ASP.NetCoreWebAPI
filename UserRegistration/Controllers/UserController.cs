using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.BusinessLogic.Interfaces;
using UserRegistration.DataAccess.DomainModels;
using UserRegistration.Helper;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration config;
        private readonly ILogger<UserController> logger;
        internal IUserManager userManager;

        public UserController(IConfiguration config, ILogger<UserController> logger, IUserManager userManager)
        {
            this.config = config;
            this.logger = logger;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await userManager.GetAllAsync();
            if (result == null)
                return NotFound(new { message = "No records found" });

            return Ok(result);
        }

        [HttpPost]
        [Route("PostUser")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
        {
            var result = await userManager.AddAsync(userDto);
            if (result == null)
                return BadRequest(new { message = "Record not added" });

            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }

        [HttpPut]
        [Route("PutUser")]
        [AllowAnonymous]
        public async Task<IActionResult> PutUser([FromBody] UserDto userDto)
        {
            var result = await userManager.UpdateAsync(userDto);
            if (result == null)
                return BadRequest(new { message = "Record not updated" });

            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [AuthorizeByRole("Admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await userManager.DeleteAsync(userId);
            if (!result)
                return BadRequest(new { message = "Record not deleted" });

            return Ok();
        }
    }
}
