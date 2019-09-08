using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.SingleStation
{
    public class PostSingleStationCommand : AbstractSingleStationCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.PostStationAsync(station);
        }
    }
}
