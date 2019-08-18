using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Station;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
{
    public class EssentialDataStationLogicService : IEssentialDataStationLogicService
    {
        private IStationDataAccessService stationDataAccessService;
        public EssentialDataStationLogicService(
            IStationDataAccessService stationDataAccessService)
        {
            this.stationDataAccessService = stationDataAccessService;
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
    }
}
