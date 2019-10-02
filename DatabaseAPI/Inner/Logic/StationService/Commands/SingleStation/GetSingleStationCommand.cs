using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.SingleStation
{
    public class GetSingleStationCommand : AbstractSingleStationCommand
    {
        public override async Task ExecuteAsync()
        {
            await essentialsService.FillStationWithEssentialDataAsync(station);
            await geographicsService.FillStationWithGeographicDataAsync(station);
        }
    }
}
