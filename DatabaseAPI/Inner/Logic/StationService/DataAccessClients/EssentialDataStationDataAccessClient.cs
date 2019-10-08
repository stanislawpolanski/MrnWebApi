using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.DataAccessClients
{
    public class EssentialDataStationDataAccessClient :
        IEssentialDataStationDataAccessClient
    {
        private IStationDataAccessService stationDataAccessService;
        public EssentialDataStationDataAccessClient(
            IStationDataAccessService stationDataAccessService)
        {
            this.stationDataAccessService = stationDataAccessService;
        }

        public async Task DeleteStationAsync(StationDTO station)
        {
            await stationDataAccessService.DeleteStationByIdAsync(station.Id);
        }

        public async Task FillCollectionWithStations(List<StationDTO> collection)
        {
            collection.AddRange(await stationDataAccessService.GetBasicStationsAsync());
        }

        public async Task FillStationWithEssentialDataAsync(StationDTO inputStation)
        {
            StationDTO station = await stationDataAccessService
                .GetDetailedStationAsync(inputStation.Id);
            inputStation.Name = station.Name;
            inputStation.OwnerId = station.OwnerId;
            inputStation.TypeOfAStationInfo = station.TypeOfAStationInfo;
        }

        public async Task PostStationAsync(StationDTO station)
        {
            await stationDataAccessService.PostStationAsync(station);
        }

        public async Task PutStationAsync(StationDTO station)
        {
            await stationDataAccessService.PutStationAsync(station);
        }
    }
}
