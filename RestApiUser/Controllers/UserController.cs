using Microsoft.AspNetCore.Mvc;
using RestApiUser.Service;

namespace RestApiUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(Name ="GetUser")]
        public IActionResult GetUser(int Id)
        {
            try
            {
                if(Id == 0)
                {
                    return BadRequest("Invalid Input");
                }
                var user = userService.User(Id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex) {
                logger.LogInformation($"Get User action failed due to {ex.Message}");
                return null;
            }

        }
    }
}
