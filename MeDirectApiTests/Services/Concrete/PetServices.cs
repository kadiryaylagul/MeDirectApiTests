using MeDirectApiTests.Actions.Abstract;
using MeDirectApiTests.Actions.Concrete;
using MeDirectApiTests.Services.Abstract;
using MeDirectApiTests.Models.Pet;
using MeDirectApiTests.Models.Pet.Requests;
using MeDirectApiTests.Models.User;
using Xunit;

namespace MeDirectApiTests.Services.Concrete {
    internal class PetServices : IPetServices {
        private IPetActions petActions;
        private BasePetResponse basePetResponse;
        private CreatePetResponse createPetResponse;

        public PetServices() {
            petActions = new PetActions();
        }

        public void CreatePetService() {
            List<Tag> tags = new List<Tag>();
            tags.Add(
                new Tag {
                    Id=0,
                    Name="TAG"
                });
            createPetResponse = petActions.CreatePetAction(new CreatePetRequest {
                Id = 0,
                Category = new Category {
                    Id = 0,
                    Name = "Dogs"
                },
                Name = "ScoobyDoo",
                PhotoUrls = new[] { "Url-1", "Url-2" },
                Tags = tags,
                Status = "Available"
            });
            Assert.True(createPetResponse.Id > 0);            
        }
        
        public void GetPetWithPetIdService(long id) {
            basePetResponse = petActions.GetPetWithIdAction(id);
            Assert.Equal("Pet not found", basePetResponse.Message);
            Assert.Equal("error", basePetResponse.Type);
        }

        public void UploadPetImageService(long id) {
            basePetResponse = petActions.UploadPetImageAction(id);

            if (basePetResponse.Code == 200) {
                Assert.NotEmpty(basePetResponse.Message);
            } else {
                Assert.Fail("Status Code : " + basePetResponse.Code + "\nMessage : " + basePetResponse.Message);
            }
        }
    }
}
