using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
{
    public interface IEssentialDataStationDataAccessClient
    {
        Task FillStationWithEssentialDataAsync(StationDTO inputStation);
        Task DeleteStationAsync(StationDTO station);
        Task PutStationAsync(StationDTO station);
        Task PostStationAsync(StationDTO station);
        Task FillCollectionWithStations(List<StationDTO> collection);
    }
}
