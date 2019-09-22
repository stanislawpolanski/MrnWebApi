using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.Railway
{
    public class DbRailwayDataAccessService : DbDataAccessAbstractService, IRailwayDataAccessService
    {
        public DbRailwayDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task<RailwayDTO> GetRailwayByIdAsync(int id)
        {
            Railways entity = await GetRailwayEntityById(id);
            if (entity == null)
            {
                return null;
            }
            RailwayDTO dto = GetRailwayDTO(entity);
            return dto;
        }

        private RailwayDTO GetRailwayDTO(Railways entity)
        {
            return new RailwayDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .WithNumber(entity.Number)
                .WithOwner(GetOwnerDTO(entity))
                .Build();
        }

        private OwnerDTO GetOwnerDTO(Railways entity)
        {
            return new OwnerDTO
                .Builder()
                .WithId(entity.Owner.Id)
                .WithName(entity.Owner.Name)
                .Build();
        }

        private async Task<Railways> GetRailwayEntityById(int id)
        {
            return await context
                .Railways
                .Include(railways => railways.Owner)
                .Where(railway => railway.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RailwayDTO>> GetRailwaysByStationIdAsync(int stationId)
        {
            Expression<System.Func<Railways, bool>> railwaysHasStation =
                railway => railway
                    .StationsToGeometries
                    .Any(stationToGeometry =>
                        stationToGeometry.StationId.Equals(stationId));

            Expression<System.Func<Railways, RailwayDTO>> selectNewDTO =
                railwayEntity => new RailwayDTO()
                {
                    Id = railwayEntity.Id,
                    Name = railwayEntity.Name,
                    Number = railwayEntity.Number,
                    Owner = new OwnerDTO()
                    {
                        Id = railwayEntity.Owner.Id,
                        Name = railwayEntity.Owner.Name
                    }
                };

            IEnumerable<RailwayDTO> result = await context
                .Railways
                .Include(railway => railway.StationsToGeometries)
                .Where(railwaysHasStation)
                .Select(selectNewDTO)
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync()
        {
            List<RailwayDTO> dtos = await context
                .Railways
                .Include(railway => railway.Owner)
                .Select(entity => GetRailwayDTO(entity))
                .ToListAsync();
            return dtos;
        }
    }
}
