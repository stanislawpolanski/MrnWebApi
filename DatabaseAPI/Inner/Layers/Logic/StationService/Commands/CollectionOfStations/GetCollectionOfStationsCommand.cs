using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.CollectionOfStations
{
    public class GetCollectionOfStationsCommand : AbstractCollectionOfStationsCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.FillCollectionWithStations(collection);
        }
    }
}
