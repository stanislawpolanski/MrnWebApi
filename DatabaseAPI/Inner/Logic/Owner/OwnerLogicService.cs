using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Owner;
using System;
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
        public async Task<OwnerDTO> GetOwnerByIdAsync(int id)
        {
            return await service.GetOwnerByIdAsync(id);
        }
    }
}
