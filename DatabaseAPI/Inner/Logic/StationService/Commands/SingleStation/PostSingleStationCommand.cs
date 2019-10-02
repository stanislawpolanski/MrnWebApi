using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.SingleStation
{
    public class PostSingleStationCommand : AbstractSingleStationCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.PostStationAsync(station);
        }
    }
}
