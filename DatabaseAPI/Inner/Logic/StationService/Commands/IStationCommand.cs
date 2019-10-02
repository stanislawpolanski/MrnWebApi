using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Logic.StationService.DataAccessClients;

namespace DatabaseAPI.Inner.Logic.StationService.Commands
{
    public interface IStationCommand : ICommand
    {
        void SetDataAcessClients(
            IEssentialDataStationDataAccessClient essentialsService,
            IGeographicDataStationDataAccessClient geographicsService);
    }
}
