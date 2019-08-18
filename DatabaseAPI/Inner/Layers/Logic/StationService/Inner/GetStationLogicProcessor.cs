using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;

namespace DatabaseAPI.Logic.StationService.Inner
{
    public class GetStationLogicProcessor : AbstractStationLogicProcessor
    {
        public GetStationLogicProcessor(
            IEssentialDataStationLogicService essentialDataService, 
            IGeographicDataStationLogicService geographicDataService) : 
            base(essentialDataService, 
                geographicDataService)
        {
        }

        public override async Task<StationDTO> GetStationAsync()
        {
            await essentialDataService
                .FillStationWithEssentialDataAsync(this.station);
            await geographicDataService
                .FillStationWithGeographicDataAsync(this.station);
            return this.station;
        }
    }
}
