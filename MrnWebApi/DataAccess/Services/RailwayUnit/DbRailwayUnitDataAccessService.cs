using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.RailwayUnit
{
    public class DbRailwayUnitDataAccessService : DbDataAccessAbstractService, IRailwayUnitDataAccessService
    {
        public DbRailwayUnitDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public RailwayUnitModel GetRailwayUnitByStationId(int stationId)
        {
            
            int stationsOwnerId = dbContext
                .Stations
                .Where(station => station.Id.Equals(stationId))
                .Include(station => station.ParentObjectOfInterest)
                .FirstOrDefault()
                .ParentObjectOfInterest
                .OwnerId;

            IGeometry stationGeometry = dbContext
                .StationsToGeometries
                .Where(relation => relation.StationId.Equals(stationId))
                .Include(relation => relation.Geometry)
                .Select(entity => entity.Geometry.SpatialData)
                .First();

            List<RailwayUnits> possibleRailwayUnits = dbContext
                .RailwayUnits
                .Include(unit => unit.Geometries)
                .Where(unit => unit.OwnerId.Equals(stationsOwnerId))
                .ToList();

            RailwayUnits selectedRailwayUnit = possibleRailwayUnits
                .Where(unit => unit.Geometries.SpatialData.Intersects(stationGeometry))
                .First();

            return new RailwayUnitModel()
            {
                Id = selectedRailwayUnit.Id,
                Name = selectedRailwayUnit.Name
            };
        }
    }
}
