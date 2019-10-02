using DatabaseAPI.Inner.Logic.RailwayService.Commands.Collection;
using DatabaseAPI.Inner.Logic.RailwayService.Commands.Single;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Factory
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
        public ICollectionOfRailwayCommand GetGetSetOfRailwaysCommand()
        {
            ICollectionOfRailwayCommand command = new GetCollectionOfRailwayCommand();
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
