
using System.Text.Json.Serialization;

namespace MeDirectApiTests.Models.Pet.Requests {
    internal class CreatePetRequest {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("photoUrls")]
        public string[] PhotoUrls { get; set; }
        
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    internal class Category {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    internal class Tag {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
