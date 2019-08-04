using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Station
{
    public class DbStationDataAccessService : DbDataAccessAbstractService, IStationDataAccessService
    {
        public DbStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task PostStationAsync(StationModel inputStation)
        {
            ObjectsOfInterest objectOfInterest = await SaveToObjectOfInterestTableAsync(inputStation);
            int newStationId = objectOfInterest.Id;
            await SaveToStationTableAsync(inputStation, newStationId);
            inputStation.Id = newStationId;
        }

        private async Task<Stations> SaveToStationTableAsync(StationModel inputStation, int newStationId)
        {
            Stations station = new Stations()
            {
                Id = newStationId,
                TypeOfAstationId = inputStation.TypeOfAStationInfo.Id
            };
            context.Stations.Add(station);
            await context.SaveChangesAsync();
            return station;
        }

        /// <summary>
        /// Saves station into Object Of Interest table. Returns the saved entity.
        /// </summary>
        /// <param name="inputStation"></param>
        /// <returns>Saved entity.</returns>
        private async Task<ObjectsOfInterest> SaveToObjectOfInterestTableAsync(StationModel inputStation)
        {
            ObjectsOfInterest objectOfInterest = new ObjectsOfInterest()
            {
                Name = inputStation.Name,
                OwnerId = inputStation.OwnerInfo.Id
            };
            context.ObjectsOfInterest.Add(objectOfInterest);
            await context.SaveChangesAsync();
            return objectOfInterest;
        }

        public async Task DeleteStationByIdAsync(int id)
        {
            Stations station = context.Stations.Find(id);
            context.Stations.Remove(station);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StationModel>> GetBasicStationsAsync()
        {
            return await context.Stations
                .Join(context.ObjectsOfInterest,
                    stationEntity => stationEntity.Id,
                    objectOfInterestEntity => objectOfInterestEntity.Id,
                    (stationEntity, objectOfInterestEntity)
                        => new StationModel { Id = stationEntity.Id, Name = objectOfInterestEntity.Name })
                .ToListAsync();
        }

        public Task<StationModel> GetDetailedStationAsync(int id)
        {
            return context
                .Stations
                .Where(station => station.Id.Equals(id))
                .Include(station => station.ParentObjectOfInterest)
                .Include(station => station.ParentObjectOfInterest.Owner)
                .Include(station => station.TypeOfAstation)
                .Select(entity => new StationModel()
                {
                    Id = entity.Id,
                    Name = entity.ParentObjectOfInterest.Name,
                    OwnerInfo = new OwnerModel()
                    {
                        Id = entity.ParentObjectOfInterest.Owner.Id,
                        Name = entity.ParentObjectOfInterest.Owner.Name
                    },
                    TypeOfAStationInfo = new TypeOfAStationModel()
                    {
                        AbbreviatedName = entity.TypeOfAstation.AbbreviatedName,
                        Id = entity.TypeOfAstation.Id
                    }
                }
                )
                .FirstOrDefaultAsync();
        }

        public async Task PutStationAsync(StationModel inputStation)
        {
            await UpdateObjectOfInterestEntityAsync(inputStation);
            await UpdateStationEntityAsync(inputStation);
            await context.SaveChangesAsync();
        }

        private async Task UpdateStationEntityAsync(StationModel inputStation)
        {
            Stations queriedStation = await context.Stations.FirstAsync(station => station.Id.Equals(inputStation.Id));
            queriedStation.TypeOfAstationId = inputStation.TypeOfAStationInfo.Id;
        }

        private async Task UpdateObjectOfInterestEntityAsync(StationModel inputStation)
        {
            ObjectsOfInterest queriedObjectOfInterest = await context.ObjectsOfInterest
                .FirstAsync(entity => entity.Id.Equals(inputStation.Id));
            queriedObjectOfInterest.Name = inputStation.Name;
            queriedObjectOfInterest.OwnerId = inputStation.OwnerInfo.Id;
        }
    }
}
