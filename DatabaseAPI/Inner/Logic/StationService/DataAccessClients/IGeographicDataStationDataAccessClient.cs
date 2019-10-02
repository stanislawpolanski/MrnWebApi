using DatabaseAPI.Inner.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.DataAccessClients
{
    public interface IGeographicDataStationDataAccessClient
    {
        Task FillStationWithGeographicDataAsync(StationDTO station);
    }
}
