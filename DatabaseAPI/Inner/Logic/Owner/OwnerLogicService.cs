using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Owner;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.Owner
{
    public class OwnerLogicService : IOwnerLogicService
    {
        private IOwnerDataAccessService service;

        public OwnerLogicService(IOwnerDataAccessService service)
        {
            this.service = service;
        }

        public async Task<bool> DeleteOwnerByIdAsync(int id)
        {
            return await service.DeleteOwnerByIdAsync(id);
        }

        public async Task<IEnumerable<OwnerDTO>> GetAllOwnersAsync()
        {
            return await service.GetAllOwnersAsync();
        }

        public async Task<OwnerDTO> GetOwnerByIdAsync(int id)
        {
            return await service.GetOwnerByIdAsync(id);
        }

        public async Task<OwnerDTO> PostOwnerAsync(OwnerDTO model)
        {
            return await service.PostOwnerAsync(model);
        }
    }
}
