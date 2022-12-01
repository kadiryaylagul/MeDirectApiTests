
using System.Text.Json.Serialization;

namespace MeDirectApiTests.Models.User {
    public  class BaseUserResponse {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;  
    }
}
