using System;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;

namespace DatabaseAPI.Logic.StationService.Inner
{
    public class PostStationLogicProcessor : AbstractStationLogicProcessor
    {
        public PostStationLogicProcessor(
            IEssentialDataStationLogicService essentialDataService, 
            IGeographicDataStationLogicService geographicDataService) : 
            base(essentialDataService, 
                geographicDataService)
        {
        }

        public override Task<StationDTO> GetStationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
