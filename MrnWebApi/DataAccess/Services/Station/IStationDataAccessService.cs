using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.Station
{
    public interface IStationDataAccessService
    {
        ICollection<BasicStationModel> GetBasicStations();
    }
}
