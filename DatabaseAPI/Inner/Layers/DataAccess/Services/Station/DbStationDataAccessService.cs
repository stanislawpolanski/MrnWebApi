using Microsoft.EntityFrameworkCore;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs.FromEntitiesAdapters;
using System.Linq.Expressions;

namespace DatabaseAPI.DataAccess.Services.Station
{
    public class DbStationDataAccessService : DbDataAccessAbstractService, IStationDataAccessService
    {
        public DbStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task PostStationAsync(StationDTO inputStation)
        {
            ObjectsOfInterest objectOfInterest =
                await SaveToObjectOfInterestTableAsync(inputStation);
            int newStationId = objectOfInterest.Id;
            await SaveToStationTableAsync(inputStation, newStationId);
            inputStation.Id = newStationId;
        }

        private async Task<Stations> SaveToStationTableAsync(
            StationDTO inputStation,
            int newStationId)
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
        private async Task<ObjectsOfInterest> SaveToObjectOfInterestTableAsync(StationDTO inputStation)
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
            Stations station = await context.Stations.FindAsync(id);
            context.Stations.Remove(station);

            ObjectsOfInterest objectsOfInterest =
                await context
                .ObjectsOfInterest
                .FindAsync(id);
            context.Remove(objectsOfInterest);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StationDTO>> GetBasicStationsAsync()
        {
            Expression<System.Func<Stations, StationDTO>> 
                selectToDTO = entity => new StationDTO()
                {
                    Id = entity.ParentObjectOfInterest.Id,
                    Name = entity.ParentObjectOfInterest.Name
                };

            return await context
                .Stations
                .Include(station => station.ParentObjectOfInterest)
                .Select(selectToDTO)
                .ToListAsync();
        }

        public async Task<StationDTO> GetDetailedStationAsync(int id)
        {
            return await context
                .Stations
                .Where(station => station.Id.Equals(id))
                .Include(station => station.ParentObjectOfInterest)
                .Include(station => station.ParentObjectOfInterest.Owner)
                .Include(station => station.TypeOfAstation)
                .Select(GetStationEntityToDTOSelectionExpression())
                .FirstOrDefaultAsync();
        }

        private Expression<System.Func<Stations, StationDTO>> 
            GetStationEntityToDTOSelectionExpression()
        {
            return entity => new StationDTO
                    .Builder()
                    .WithId(entity.Id)
                    .WithName(entity.ParentObjectOfInterest.Name)
                    .WithOwner(new OwnerDTO
                        .Builder()
                        .WithId(entity.ParentObjectOfInterest.Owner.Id)
                        .WithName(entity.ParentObjectOfInterest.Owner.Name)
                        .Build())
                    .WithTypeOfAStation(new TypeOfAStationDTO
                        .Builder()
                        .WithId(entity.TypeOfAstation.Id)
                        .WithAbbreviatedName(entity.TypeOfAstation.AbbreviatedName)
                        .Build())
                    .Build();
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            await UpdateObjectOfInterestEntityAsync(inputStation);
            await UpdateStationEntityAsync(inputStation);
            await context.SaveChangesAsync();
        }

        private async Task UpdateStationEntityAsync(StationDTO inputStation)
        {
            Stations queriedStation =
                await context
                    .Stations
                    .FirstAsync(station => station.Id.Equals(inputStation.Id));
            queriedStation.TypeOfAstationId = inputStation.TypeOfAStationInfo.Id;
        }

        private async Task UpdateObjectOfInterestEntityAsync(StationDTO inputStation)
        {
            ObjectsOfInterest queriedObjectOfInterest = await context
                .ObjectsOfInterest
                //todo should't be SingleAsync()?
                .FirstAsync(entity => entity.Id.Equals(inputStation.Id));
            queriedObjectOfInterest.Name = inputStation.Name;
            queriedObjectOfInterest.OwnerId = inputStation.OwnerInfo.Id;
        }
    }
}
