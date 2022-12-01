
using System.Net;
using MeDirectApiTests.Models.User;
using MeDirectApiTests.Models.User.Requests;
using RestSharp;

namespace MeDirectApiTests.Actions.Abstract {
    public  interface IUserActions {
        BaseUserResponse UserLoginAction(string userName, string password);
        BaseUserResponse UserLogoutAction();
        BaseUserResponse CreateUserAction(CreateUserRequest createUserRequest);
        BaseUserResponse CreateUserWithListAction(List<CreateUserRequest> createUserRequests);
        T GetUserByUserNameAction<T>(string userName, HttpStatusCode httpStatusCode);
        BaseUserResponse UpdateUserByUserNameAction(string userName, CreateUserRequest createUserRequest);
        BaseUserResponse DeleteUserByUserNameAction(string userName);
    }
}
