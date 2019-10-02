using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.SingleStation
{
    public class DeleteSingleStationCommand : AbstractSingleStationCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.DeleteStationAsync(station);
        }
    }
}
