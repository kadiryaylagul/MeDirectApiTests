using System.Net;
using System.Xml.Linq;
using MeDirectApiTests.Actions.Abstract;
using MeDirectApiTests.Actions.Concrete;
using MeDirectApiTests.Constants.Messages.UserMessages;
using MeDirectApiTests.Models.User;
using MeDirectApiTests.Models.User.Requests;
using MeDirectApiTests.Models.User.Responses;
using MeDirectApiTests.Services.Abstract;
using Newtonsoft.Json;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace MeDirectApiTests.Services.Concrete {
    public class UserServices : IUserServices {
        private IUserActions userActions;
        private BaseUserResponse baseUserResponse;
        private GetUserResponse getUserResponse;

        public UserServices() {
            userActions = new UserActions();
        }

        public void UserLoginService(string userName, string password) {
            baseUserResponse = userActions.UserLoginAction(userName, password);

            if (baseUserResponse.Code == 200) {
                Assert.Contains("logged in user session:", baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }

        public void UserLogoutService() {
            baseUserResponse = userActions.UserLogoutAction();

            if (baseUserResponse.Code == 200) {
                Assert.Equal("ok", baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }

        public void CreateUserService() {
            baseUserResponse = userActions.CreateUserAction(new CreateUserRequest {
                Id = 0,
                FirstName = "McDirect",
                LastName = "Api",
                Email = "McDirectApi@md.com",
                UserName = "McDirectApi",
                Password = "12345",
                Phone = "05555555555",
                UserStatus = 0
            });

            if (baseUserResponse.Code == 200) {
                Assert.NotEmpty(baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }

        public void CreateUserWithListService() {
            List<CreateUserRequest> createUserRequests = new List<CreateUserRequest>();
            createUserRequests.Add(
                new CreateUserRequest {
                    Id = 0,
                    FirstName = "Kadir",
                    LastName = "yaylagül",
                    Email = "McDirectApi@md.com",
                    UserName = "kadiryay",
                    Password = "324234",
                    Phone = "05325555555",
                    UserStatus = 0
                }
            );
            createUserRequests.Add(
                new CreateUserRequest {
                    Id = 0, 
                    FirstName = "Mert", 
                    LastName = "Namert", 
                    Email = "McDirectApi@md.com", 
                    UserName = "MertNamert", 
                    Password = "324234", 
                    Phone = "05325555555", 
                    UserStatus = 0 }
            );

            baseUserResponse = userActions.CreateUserWithListAction(createUserRequests);

            if (baseUserResponse.Code == 200) {
                Assert.NotEmpty(baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }

        public void GetUserByUserNameService(string userName, HttpStatusCode httpStatusCode) {
            if (httpStatusCode == HttpStatusCode.OK) {
                getUserResponse = userActions.GetUserByUserNameAction<GetUserResponse>(userName, httpStatusCode);
                Assert.True(getUserResponse.Id > 0);
                Assert.NotEmpty(getUserResponse.UserName);
                Assert.NotEmpty(getUserResponse.Password);
                Assert.NotEmpty(getUserResponse.Email);
            } else if (httpStatusCode == HttpStatusCode.NotFound) {
                baseUserResponse = userActions.GetUserByUserNameAction<BaseUserResponse>(userName, httpStatusCode);
                Assert.Equal("User not found", baseUserResponse.Message);
                Assert.Equal(1, baseUserResponse.Code);
                Assert.Equal("error", baseUserResponse.Type);
            } else {
                Assert.Fail(UserMessageConstants.USER_NOT_GET);
            }
        }

        public void UpdateUserByUserNameService(string userName) {
            baseUserResponse = userActions.UpdateUserByUserNameAction(userName, new CreateUserRequest {
                Id = 0, 
                FirstName = "McDirect", 
                LastName = "Updated", 
                Email = "McDirectApi@md.com", 
                UserName = "McDirectApi", 
                Password = "12345", 
                Phone = "05555555555", 
                UserStatus = 0 });

            if (baseUserResponse.Code == 200) {
                Assert.NotEmpty(baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }
        public void DeleteUserByUserNameService(string userName) {
            baseUserResponse = userActions.UpdateUserByUserNameAction(userName, new CreateUserRequest {
                Id = 0, 
                FirstName = "McDirect", 
                LastName = "Updated", 
                Email = "McDirectApi@md.com", 
                UserName = "McDirectApi", 
                Password = "12345", 
                Phone = "05555555555", 
                UserStatus = 0 });

            if (baseUserResponse.Code == 200) {
                Assert.NotEmpty(baseUserResponse.Message);
            } else {
                Assert.Fail("Status Code : " + baseUserResponse.Code + "\nMessage : " + baseUserResponse.Message);
            }
        }

    }
}
