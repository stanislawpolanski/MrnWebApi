﻿using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<StationModel> GetAllBasicStations();
        Task<StationModel> GetDetailedStationByIdAsync(int id);
        Task AddStationAsync(StationModel inputStation);
        Task DeleteStationByIdAsync(int id);
        Task UpdateStationAsync(StationModel inputStation);
    }
}
