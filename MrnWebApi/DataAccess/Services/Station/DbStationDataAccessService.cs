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

        public int AddStation(StationModel inputStation)
        {
            ObjectsOfInterest objectOfInterest = SaveToObjectOfInterestTable(inputStation);
            int newStationId = objectOfInterest.Id;
            SaveToStationTable(inputStation, newStationId);
            return newStationId;
        }

        private Stations SaveToStationTable(StationModel inputStation, int newStationId)
        {
            Stations station = new Stations()
            {
                Id = newStationId,
                TypeOfAstationId = inputStation.TypeOfAStationInfo.Id
            };
            context.Stations.Add(station);
            context.SaveChanges();
            return station;
        }

        /// <summary>
        /// Saves station into Object Of Interest table. Returns the saved entity.
        /// </summary>
        /// <param name="inputStation"></param>
        /// <returns>Saved entity.</returns>
        private ObjectsOfInterest SaveToObjectOfInterestTable(StationModel inputStation)
        {
            ObjectsOfInterest objectOfInterest = new ObjectsOfInterest()
            {
                Name = inputStation.Name,
                OwnerId = inputStation.OwnerInfo.Id
            };
            context.ObjectsOfInterest.Add(objectOfInterest);
            context.SaveChanges();
            return objectOfInterest;
        }

        public void DeleteStationById(int id)
        {
            Stations station = context.Stations.Find(id);
            context.Stations.Remove(station);
            context.SaveChanges();
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
                .FirstOrDefault();
        }

        public void UpdateStation(StationModel inputStation)
        {
            UpdateObjectOfInterestEntity(inputStation);
            UpdateStationEntity(inputStation);
            context.SaveChanges();
        }

        private void UpdateStationEntity(StationModel inputStation)
        {
            Stations queriedStation = context.Stations.First(station => station.Id.Equals(inputStation.Id));
            queriedStation.TypeOfAstationId = inputStation.TypeOfAStationInfo.Id;
        }

        private void UpdateObjectOfInterestEntity(StationModel inputStation)
        {
            ObjectsOfInterest queriedObjectOfInterest = context.ObjectsOfInterest
                .First(entity => entity.Id.Equals(inputStation.Id));
            queriedObjectOfInterest.Name = inputStation.Name;
            queriedObjectOfInterest.OwnerId = inputStation.OwnerInfo.Id;
        }
    }
}
