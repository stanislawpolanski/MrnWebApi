﻿using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        Task<IEnumerable<StationDTO>> GetBasicStationsAsync();
        Task<StationDTO> GetDetailedStationAsync(int id);
        Task PostStationAsync(StationDTO inputStation);
        Task DeleteStationByIdAsync(int id);
        Task PutStationAsync(StationDTO station);
        Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsLocationsByRailwayAsync(RailwayDTO railway);
        Task<IEnumerable<StationOnARailwayLocationDTO>> 
            GetStationsByRailwayIdAsync(int railwayId);
    }
}
