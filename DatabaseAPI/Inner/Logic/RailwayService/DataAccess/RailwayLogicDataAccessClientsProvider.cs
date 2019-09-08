using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess
{
    public class RailwayLogicDataAccessClientsProvider : 
        IRailwayLogicDataAccessClientsProvider
    {
        private IRailwayDataEssentialsClient essentialsClient;
        private IRailwayDataStationsClient stationsClient;

        public RailwayLogicDataAccessClientsProvider(
            IRailwayDataEssentialsClient essentialsClient,
            IRailwayDataStationsClient stationsClient)
        {
            this.essentialsClient = essentialsClient;
            this.stationsClient = stationsClient;
        }

        public void InjectClients(IRailwayCommand command)
        {
            command.SetEssentialsClient(essentialsClient);
            if(command is ISingleRailwayCommand singleRailwayCommand)
            {
                singleRailwayCommand.SetStationsClient(stationsClient);
            }
        }
    }
}
