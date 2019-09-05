using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Factory;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Set;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands
{
    public class RailwayCommandFactory : IRailwayCommandFactory
    {
        private IRailwayDataEssentialsClient essentialsClient;
        private IRailwayDataStationsClient stationsClient;

        public RailwayCommandFactory(
            IRailwayDataEssentialsClient essentialsClient,
            IRailwayDataStationsClient stationsClient)
        {
            this.essentialsClient = essentialsClient;
            this.stationsClient = stationsClient;
        }
        public ISetOfRailwayCommand GetGetSetOfRailwaysCommand()
        {
            ISetOfRailwayCommand command = new GetSetOfRailwayCommand();
            command.SetEssentialsClient(essentialsClient);
            return command;
        }

        public ISingleRailwayCommand GetGetSingleRailwayCommand()
        {
            ISingleRailwayCommand command = new GetSingleRailwayCommand();
            command.SetEssentialsClient(essentialsClient);
            command.SetStationsClient(stationsClient);
            return command;
        }
    }
}
