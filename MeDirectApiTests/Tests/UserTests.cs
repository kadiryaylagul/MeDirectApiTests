using System.Net;
using MeDirectApiTests.Services.Abstract;
using MeDirectApiTests.Services.Concrete;
using Xunit;

namespace MeDirectApiTests.Tests {
    public class UserTests {
        public IUserServices userServices;

        public UserTests() {
            userServices = new UserServices();
        }

        [Theory(DisplayName = "UserLogin")]
        [InlineData("kadir", "12345")]
        [InlineData("mert", "namert")]
        public void UserLogin(string userName, string password) {
            userServices.UserLoginService(userName, password);
        }
        
        [Fact(DisplayName = "UserLogout")]
        public void UserLogout() {
            userServices.UserLogoutService();
        }
    
        [Fact(DisplayName = "CreateUser")]        
        public void CreateUser() {
            userServices.CreateUserService();
        }
        
        [Fact(DisplayName = "CreateUserWithList")]        
        public void CreateUserWithList() {
            userServices.CreateUserWithListService();
        }

        [Theory(DisplayName = "GetUserByUserName")]
        [InlineData("McDirectApi", HttpStatusCode.OK)]
        [InlineData("user2", HttpStatusCode.NotFound)]
        public void GetUserByUserName(string userName, HttpStatusCode httpStatusCode) {
            userServices.GetUserByUserNameService(userName, httpStatusCode);
        }

        [Theory(DisplayName = "UpdateUserByUserName")]
        [InlineData("McDirectApi")]
        public void UpdateUserByUserName(string userName) {
            userServices.UpdateUserByUserNameService(userName);
        }

        [Theory(DisplayName = "DeleteUserByUserName")]
        [InlineData("McDirectApi")]
        public void DeleteUserByUserName(string userName) {
            userServices.DeleteUserByUserNameService(userName);
        }
    }
}
