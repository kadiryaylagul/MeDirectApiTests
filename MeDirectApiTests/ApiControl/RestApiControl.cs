using RestSharp;

namespace MeDirectApiTests.ApiControl {
    public class RestApiControl {
        internal static RestClient client;
        internal static RestRequest request;

        static RestApiControl() {
            client = new RestClient();
        }

        public static void SetRequest(Method method) {
            request = new RestRequest(method);
        }

        public static RestRequest GetRequest() {
            return request;
        }
        
        public static void RequestAddJsonBody(object obj) {
            request.AddJsonBody(obj);
        }
        
        public static void RequestAddHeader(string headerName, string headerValue) {
            request.AddHeader(headerName, headerValue);
        }
        
        public static void RequestAddFile(string name, string filePath) {
            request.AddFile(name, filePath);
        }
        
        public static void RequestAlwaysMultipartFormData(bool status) {
            request.AlwaysMultipartFormData = status;
        }

        public static void SetBaseUrl(Uri uri) {
            client.BaseUrl = uri;
        }

        public static IRestResponse Execute() {
            return client.Execute(request);
        }
    }
}
