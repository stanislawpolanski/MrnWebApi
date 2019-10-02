using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.StationService.Commands.CollectionOfStations
{
    public class GetCollectionOfStationsCommand : AbstractCollectionOfStationsCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.FillCollectionWithStations(collection);
        }
    }
}
