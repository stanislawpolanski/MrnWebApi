using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<BasicStationModel> GetBasicStations();
    }
}
