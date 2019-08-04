using MrnWebApi.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        Task<IEnumerable<StationModel>> GetAllBasicStationsAsync();
        Task<StationModel> GetStationByIdAsync(int id);
        Task PostStationAsync(StationModel inputStation);
        Task DeleteStationByIdAsync(int id);
        Task PutStationAsync(StationModel inputStation);
    }
}
