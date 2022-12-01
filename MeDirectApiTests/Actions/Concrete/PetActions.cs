
using System.Net;
using System.Text.Json;
using System.Web.Http;
using MeDirectApiTests.Actions.Abstract;
using MeDirectApiTests.ApiControl;
using MeDirectApiTests.Constants;
using MeDirectApiTests.Constants.Messages.UserMessages;
using MeDirectApiTests.Models.Pet;
using MeDirectApiTests.Models.Pet.Requests;
using MeDirectApiTests.Models.User;
using MeDirectApiTests.Models.User.Requests;
using RestSharp;

namespace MeDirectApiTests.Actions.Concrete {
    internal class PetActions : IPetActions {
        private BasePetResponse basePetResponse;
        private CreatePetResponse createPetResponse;
        private IRestResponse restResponse;
        private readonly string PetBaseUrl;


        public PetActions() {
            PetBaseUrl = BaseConstants.BASE_URL + "pet/";
            basePetResponse = new BasePetResponse();
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

        public CreatePetResponse CreatePetAction(CreatePetRequest createPetRequest) {
            RestApiControl.SetRequest(Method.POST);
            RestApiControl.SetBaseUrl(new Uri(PetBaseUrl));
            RestApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createPetRequest));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<CreatePetResponse>(restResponse, HttpStatusCode.OK);
        }

        public BasePetResponse GetPetWithIdAction(long id) {
            RestApiControl.SetRequest(Method.GET);
            RestApiControl.SetBaseUrl(new Uri(PetBaseUrl + id));
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BasePetResponse>(restResponse, HttpStatusCode.NotFound);
        }

        public BasePetResponse UploadPetImageAction(long id) {
            RestApiControl.SetRequest(Method.POST);
            RestApiControl.SetBaseUrl(new Uri(PetBaseUrl + id + "/uploadImage"));
            RestApiControl.RequestAddHeader("Content-Type", "multipart/form-data");
            RestApiControl.RequestAlwaysMultipartFormData(true);
            RestApiControl.RequestAddFile("file", Directory.GetCurrentDirectory() + "/Image/dog.jpg");
            restResponse = RestApiControl.Execute();

            return StatusCodeControl<BasePetResponse>(restResponse, HttpStatusCode.OK);

        }
    }
}
