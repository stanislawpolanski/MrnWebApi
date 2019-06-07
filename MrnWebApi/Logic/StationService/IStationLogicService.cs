using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<StationBasicModel> GetBasicStations();
        StationDetailedModel GetDetailedStation(int id);
    }
}
