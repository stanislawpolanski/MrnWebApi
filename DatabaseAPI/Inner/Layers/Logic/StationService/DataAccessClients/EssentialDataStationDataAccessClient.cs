using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
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
            inputStation.OwnerInfo = new OwnerDTO
                .Builder()
                .WithId(station.OwnerInfo.Id)
                .WithName(station.OwnerInfo.Name)
                .Build();
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
