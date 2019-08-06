using MrnWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.StationToPhoto
{
    public interface IStationToRailwayRelationshipDataAccessService
    {
        /// <summary>
        /// Updates the relationships dataset. Adds new relationships in the input, deletes those unpresent and keeps
        /// that are the same in both input and stored datasets.
        /// </summary>
        /// <param name="stationId">Model of the input station. Only id is taken into account.</param>
        /// <param name="railway">Models of railways related to the station. Only ids of the input railways
        /// are taken into account.</param>
        void UpdateRelationships(StationModel station, IEnumerable<RailwayModel> railways);
        Task DeleteRelationshipsByStationIdAsync(int stationId);
        Task ClearGeometryInfoFromRelationshipEntityByStationidAsync(int id);
    }
}
