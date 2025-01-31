using Microsoft.Extensions.Logging;
using Moq;
using RestApiUser.Controllers;
using RestApiUser.Service;

namespace RestApiUser.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UserController _userController;
        private readonly Mock<ILogger<UserController>> _mockLogger;

        public UserControllerTest()
        {
            _mockService = new Mock<IUserService>();
            _userController = new UserController( _mockLogger.Object, _mockService.Object);
        }
    }
}
