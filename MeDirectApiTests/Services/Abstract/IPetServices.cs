using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirectApiTests.Services.Abstract {
    public interface IPetServices {
        void CreatePetService();
        void UploadPetImageService(long id);
        void GetPetWithPetIdService(long id);
    }
}
