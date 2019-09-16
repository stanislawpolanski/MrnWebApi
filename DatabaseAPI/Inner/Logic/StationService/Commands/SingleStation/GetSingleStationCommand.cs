using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.Implementations
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
