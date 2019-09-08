using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands
{
    public interface IStationCommand : ICommand
    {
        void SetDataAcessClients(
            IEssentialDataStationDataAccessClient essentialsService,
            IGeographicDataStationDataAccessClient geographicsService);
    }
}
