using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.StationToRailway
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
        void UpdateRelationships(StationDTO station, IEnumerable<RailwayDTO> railways);
        Task DeleteRelationshipsByStationIdAsync(int stationId);
        Task ClearGeometryInfoFromRelationshipEntityByStationidAsync(int id);
    }
}
