﻿using Microsoft.EntityFrameworkCore;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs.FromEntitiesAdapters;

namespace DatabaseAPI.DataAccess.Services.Railway
{
    public class DbRailwayDataAccessService : DbDataAccessAbstractService, IRailwayDataAccessService
    {
        public DbRailwayDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
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
    }
}