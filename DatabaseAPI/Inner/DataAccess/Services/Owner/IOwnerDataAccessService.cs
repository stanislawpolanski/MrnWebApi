using DatabaseAPI.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Owner
{
    public interface IOwnerDataAccessService
    {
        Task<OwnerDTO> GetOwnerByIdAsync(int id);
    }
}
