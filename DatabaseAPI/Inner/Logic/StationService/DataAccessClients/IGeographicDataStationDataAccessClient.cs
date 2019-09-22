using DatabaseAPI.Common.DTOs;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
{
    public interface IGeographicDataStationDataAccessClient
    {
        Task FillStationWithGeographicDataAsync(StationDTO station);
    }
}
