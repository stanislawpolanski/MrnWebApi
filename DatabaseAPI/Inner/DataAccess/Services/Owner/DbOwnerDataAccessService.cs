using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        public async Task<bool> DeleteOwnerByIdAsync(int id)
        {
            Owners entity = await context.Owners.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            context.Owners.Remove(entity);
            await context.SaveChangesAsync();
            return true;
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

        public async Task<OwnerDTO> PostOwnerAsync(OwnerDTO dto)
        {
            Owners entity = OwnerMapper.MapToEntity(dto);
            context.Owners.Add(entity);
            await context.SaveChangesAsync();
            return OwnerMapper.MapToDTO(entity);
        }
    }
}
