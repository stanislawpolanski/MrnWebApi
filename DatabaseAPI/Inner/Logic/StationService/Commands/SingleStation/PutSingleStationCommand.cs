using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Commands.SingleStation
{
    public class PutSingleStationCommand : AbstractSingleStationCommand
    {
        public async override Task ExecuteAsync()
        {
            await essentialsService.PutStationAsync(station);
        }
    }
}
