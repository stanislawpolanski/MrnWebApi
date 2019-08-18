using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public interface IStationCommand
    {
        void SetServices(IEssentialDataStationLogicService essentialsService,
            IGeographicDataStationLogicService geographicsService);
        Task ExecuteAsync();
    }
}
