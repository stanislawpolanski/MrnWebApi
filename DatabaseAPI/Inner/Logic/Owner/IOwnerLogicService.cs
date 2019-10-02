using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.Owner
{
    public interface IOwnerLogicService
    {
        Task<OwnerDTO> GetOwnerByIdAsync(int id);
        Task<IEnumerable<OwnerDTO>> GetAllOwnersAsync();
    }
}
