﻿using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Station
{
    public class DbStationDataAccessService : DbDataAccessAbstractService, IStationDataAccessService
    {
        public DbStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public ICollection<StationModel> GetBasicStations()
        {
            return context.Stations
                .Join(context.ObjectsOfInterest,
                    stationEntity => stationEntity.Id,
                    objectOfInterestEntity => objectOfInterestEntity.Id,
                    (stationEntity, objectOfInterestEntity)
                        => new StationModel { Id = stationEntity.Id, Name = objectOfInterestEntity.Name })
                .ToList();
        }

        public StationModel GetDetailedStation(int id)
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
                .First();
        }
    }
}
