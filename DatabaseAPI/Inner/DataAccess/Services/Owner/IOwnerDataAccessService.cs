using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Owner
{
    public interface IOwnerDataAccessService
    {
        Task<OwnerDTO> GetOwnerByIdAsync(int id);
        Task<IEnumerable<OwnerDTO>> GetAllOwnersAsync();
        Task<OwnerDTO> PostOwnerAsync(OwnerDTO dto);
        Task<bool> DeleteOwnerByIdAsync(int id);
    }
}
