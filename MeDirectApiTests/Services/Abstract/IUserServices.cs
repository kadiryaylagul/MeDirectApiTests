
using System.Net;

namespace MeDirectApiTests.Services.Abstract {
    public interface IUserServices {
        void UserLoginService(string userName, string password);

        void UserLogoutService();

        void CreateUserService();

        void CreateUserWithListService();

        void GetUserByUserNameService(string userName, HttpStatusCode httpStatusCode);

        void UpdateUserByUserNameService(string userName);

        void DeleteUserByUserNameService(string userName);
    }
}
