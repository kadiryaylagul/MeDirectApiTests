
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeDirectApiTests.Models.Pet {
    internal class BasePetResponse {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
