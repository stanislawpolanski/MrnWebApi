using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Station
{
    public class GetStationDataAccessService : DbDataAccessAbstractService
    {
        public GetStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
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

        public async Task<IEnumerable<StationOnARailwayDTO>>
            GetStationsLocationsByRailwayAsync(RailwayDTO railway)
        {
            List<StationsToGeometries> entities = await GetLocationEntities(railway);
            IEnumerable<StationOnARailwayDTO> dtos = GetLocationDTOs(entities);
            return dtos;
        }

        private static IEnumerable<StationOnARailwayDTO>
             GetLocationDTOs(List<StationsToGeometries> entities)
        {
            return entities
                .Select(entity =>
                    new StationOnARailwayDTO
                    .Builder()
                    .WithStationId(entity.Station.Id)
                    .WithName(entity.Station.ParentObjectOfInterest.Name)
                    .WithKmPosts(entity.BeginningKmpost,
                                 entity.CentreKmpost,
                                 entity.EndingKmpost)
                    .Build());
        }

        private async Task<List<StationsToGeometries>> GetLocationEntities(
            RailwayDTO railway)
        {
            return await context
                .StationsToGeometries
                .Include(relationship => relationship.Station)
                .Include(relationship => relationship.Station.ParentObjectOfInterest)
                .Where(relationship => relationship.RailwayId.Equals(railway.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<StationOnARailwayDTO>>
             GetStationsByRailwayIdAsync(int railwayId)
        {
            IEnumerable<StationsToGeometries> entities =
                await ReadStationsFromContextByRailwayId(railwayId);
            if (entities.Count() == 0)
            {
                return null;
            }
            Func<StationsToGeometries, StationOnARailwayDTO> mapEntityToDto =
                dto => StationToGeometryEntityToStationOnARailwayDTOMapper
                       .MapToDTO(dto);
            return entities.Select(mapEntityToDto).ToList();
        }

        private async Task<IEnumerable<StationsToGeometries>>
    ReadStationsFromContextByRailwayId(int railwayId)
        {
            return await context
                .StationsToGeometries
                .Include(entity => entity.Station)
                .Include(entity => entity.Station.ParentObjectOfInterest)
                .Where(entity => entity.RailwayId == railwayId)
                .ToListAsync();
        }
    }
}
