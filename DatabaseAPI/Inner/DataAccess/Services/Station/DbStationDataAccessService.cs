using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Station
{
    public class DbStationDataAccessService : DbDataAccessAbstractService,
        IStationDataAccessService
    {
        public DbStationDataAccessService(MRN_developContext injectedContext) :
            base(injectedContext)
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
            ObjectsOfInterest objectOfInterest = 
                ObjectOfInterestToStationMapper.MapToEntity(inputStation);
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
            IEnumerable<Stations> entities = await ReadAllEntities();

            Func<Stations, StationDTO> entityToDTO = entity =>
                new StationDTO
                .Builder()
                .WithId(entity.ParentObjectOfInterest.Id)
                .WithName(entity.ParentObjectOfInterest.Name)
                .Build();

            List<StationDTO> dtos = entities.Select(entityToDTO).ToList();

            return dtos;
        }

        private async Task<IEnumerable<Stations>> ReadAllEntities()
        {
            return await context
                .Stations
                .Include(station => station.ParentObjectOfInterest)
                .ToListAsync();
        }

        public async Task<StationDTO> GetDetailedStationAsync(int id)
        {
            Stations entity = await GetEntityFromContextById(id);
            StationDTO dto = GetDTOFromEntity(entity);
            return dto;
        }

        private async Task<Stations> GetEntityFromContextById(int id)
        {
            return await context
                .Stations
                .Where(station => station.Id.Equals(id))
                .Include(station => station.ParentObjectOfInterest)
                .Include(station => station.ParentObjectOfInterest.Owner)
                .Include(station => station.TypeOfAstation)
                .FirstOrDefaultAsync();
        }

        private StationDTO GetDTOFromEntity(Stations entity)
        {
            TypeOfAStationDTO typeOfAStation = GetTypeOfAStationDTOFromEntity(entity);
            return new StationDTO
                    .Builder()
                    .WithId(entity.Id)
                    .WithName(entity.ParentObjectOfInterest.Name)
                    .WithOwnerId(entity.ParentObjectOfInterest.OwnerId)
                    .WithTypeOfAStation(typeOfAStation)
                    .Build();
        }

        private static TypeOfAStationDTO GetTypeOfAStationDTOFromEntity(Stations entity)
        {
            if (entity.TypeOfAstation == null)
            {
                return null;
            }
            return new TypeOfAStationDTO
                        .Builder()
                        .WithId(entity.TypeOfAstation.Id)
                        .WithAbbreviatedName(entity.TypeOfAstation.AbbreviatedName)
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
                .FirstAsync(entity => entity.Id.Equals(inputStation.Id));
            queriedObjectOfInterest.Name = inputStation.Name;
            queriedObjectOfInterest.OwnerId = inputStation.OwnerId;
        }

        public async Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsLocationsByRailwayAsync(RailwayDTO railway)
        {
            List<StationsToGeometries> entities = await GetLocationEntities(railway);
            IEnumerable<StationOnARailwayLocationDTO> dtos = GetLocationDTOs(entities);
            return dtos;
        }

        private static IEnumerable<StationOnARailwayLocationDTO>
            GetLocationDTOs(List<StationsToGeometries> entities)
        {
            return entities
                .Select(entity =>
                    new StationOnARailwayLocationDTO
                    .Builder()
                    .WithStationId(entity.Station.Id)
                    .WithName(entity.Station.ParentObjectOfInterest.Name)
                    .WithKmPosts(entity.BeginningKmpost,
                                 entity.CentreKmpost,
                                 entity.EndingKmpost)
                    .Build());
        }

        private async Task<List<StationsToGeometries>> GetLocationEntities(RailwayDTO railway)
        {
            return await context
                .StationsToGeometries
                .Include(relationship => relationship.Station)
                .Include(relationship => relationship.Station.ParentObjectOfInterest)
                .Where(relationship => relationship.RailwayId.Equals(railway.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsByRailwayIdAsync(int railwayId)
        {
            IEnumerable<StationsToGeometries> entities =
                await context
                .StationsToGeometries
                .Include(relationship => relationship.Station)
                .Include(relationship => relationship.Station.ParentObjectOfInterest)
                .Where(relationship => relationship.RailwayId == railwayId)
                .ToListAsync();

            var collectionOfDtos = new List<StationOnARailwayLocationDTO>();

            foreach(var entity in entities)
            {
                var dto = StationToGeometryEntityToStationOnARailwayDTOMapper
                    .MapToDTO(entity);
                collectionOfDtos.Add(dto);
            }
            return collectionOfDtos;
        }
    }
}
