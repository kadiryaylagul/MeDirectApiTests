using MeDirectApiTests.Models.Pet;
using MeDirectApiTests.Models.Pet.Requests;

namespace MeDirectApiTests.Actions.Abstract {
    internal interface IPetActions {
        CreatePetResponse CreatePetAction(CreatePetRequest createPetRequest);
        BasePetResponse UploadPetImageAction(long id);
        BasePetResponse GetPetWithIdAction(long id);
    }
}
