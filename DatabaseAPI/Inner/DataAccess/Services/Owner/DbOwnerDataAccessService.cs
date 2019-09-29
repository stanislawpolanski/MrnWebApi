using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.DataAccess.Services;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Inner.DataAccess.Services.Owner
{
    public class DbOwnerDataAccessService : 
        DbDataAccessAbstractService,
        IOwnerDataAccessService
    {
        public DbOwnerDataAccessService(MRN_developContext injectedContext) 
            : base(injectedContext)
        {
        }

        public async Task<IEnumerable<OwnerDTO>> GetAllOwnersAsync()
        {
            var entities = await context
                .Owners
                .Select(entity => OwnerMapper.MapToDTO(entity))
                .ToListAsync();
            return entities;
        }

        public async Task<OwnerDTO> GetOwnerByIdAsync(int id)
        {
            return await context
                .Owners
                .Where(owner => owner.Id == id)
                .Select(owner => OwnerMapper.MapToDTO(owner))
                .FirstOrDefaultAsync();
        }
    }
}
