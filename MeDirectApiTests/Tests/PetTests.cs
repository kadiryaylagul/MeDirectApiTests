using MeDirectApiTests.Services.Abstract;
using MeDirectApiTests.Services.Concrete;
using Xunit;

namespace MeDirectApiTests.Tests {
    public class PetTests {
        public IPetServices petServices;

        public PetTests() {
            petServices = new PetServices();
        }

        [Fact(DisplayName = "Create Pet")]
        public void CreatePet() {
            petServices.CreatePetService();
        }

        [Theory(DisplayName = "Get Pet")]
        [InlineData(1)]
        public void GetPetWithPetId(long id) {
            petServices.GetPetWithPetIdService(id);
        }

        [Theory(DisplayName = "Upload Pet Image With Id")]
        [InlineData(1)]
        public void UploadPetImage(long id) {
            petServices.UploadPetImageService(id);
        }
    }
}
