using System.Net;
using System.Text.Json;
using System.Web.Http;
using MeDirectApiTests.Actions.Abstract;
using MeDirectApiTests.ApiControl;
using MeDirectApiTests.Constants;
using MeDirectApiTests.Constants.Messages.UserMessages;
using MeDirectApiTests.Models.User;
using MeDirectApiTests.Models.User.Requests;
using RestSharp;

namespace MeDirectApiTests.Actions.Concrete {
    public class UserActions : IUserActions {
        private BaseUserResponse baseUserResponse;
        private IRestResponse restResponse;
        private readonly string UserBaseUrl;


        public UserActions() {
            UserBaseUrl = BaseConstants.BASE_URL + "user/";
            baseUserResponse = new BaseUserResponse();
        }

        private T JsonDeserialize<T>(IRestResponse restResponse) {
            return JsonSerializer.Deserialize<T>(restResponse.Content);
        }

        private T StatusCodeControl<T>(IRestResponse restResponse, HttpStatusCode statusCode) {
            if (restResponse.StatusCode == statusCode) {
                return JsonDeserialize<T>(restResponse);
            } else {
                throw new HttpResponseException(restResponse.StatusCode);
            }
        }

        public BaseUserResponse UserLoginAction(string userName, string password) {
            RestApiControl.SetRequest(Method.GET);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + "login" + "?username=" + userName + "&password=" + password));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }
        public BaseUserResponse UserLogoutAction() {
            RestApiControl.SetRequest(Method.GET);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + "logout"));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }

        public BaseUserResponse CreateUserAction(CreateUserRequest createUserRequest) {
            RestApiControl.SetRequest(Method.POST);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl));
            RestApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequest));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }

        public BaseUserResponse CreateUserWithListAction(List<CreateUserRequest> createUserRequests) {
            RestApiControl.SetRequest(Method.POST);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + "createWithList"));
            RestApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequests));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }

        public T GetUserByUserNameAction<T>(string userName, HttpStatusCode httpStatusCode) {
            RestApiControl.SetRequest(Method.GET);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<T>(restResponse, httpStatusCode);
        }

        public BaseUserResponse UpdateUserByUserNameAction(string userName, CreateUserRequest createUserRequest) {
            RestApiControl.SetRequest(Method.PUT);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            RestApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequest));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }
        public BaseUserResponse DeleteUserByUserNameAction(string userName) {
            RestApiControl.SetRequest(Method.DELETE);
            RestApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BaseUserResponse>(restResponse, HttpStatusCode.OK);
        }
    }
}
