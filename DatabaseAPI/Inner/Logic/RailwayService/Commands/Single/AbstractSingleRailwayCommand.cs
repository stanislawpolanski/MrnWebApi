using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RailwayService.DataAccess;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Single
{
    public abstract class AbstractSingleRailwayCommand : ISingleRailwayCommand
    {
        protected IRailwayDataEssentialsClient essentialsClient;
        protected IRailwayDataStationsClient stationsClient;
        protected RailwayDTO inputRailway;
        protected RailwayDTO executionResult;

        public abstract Task ExecuteAsync();

        public RailwayDTO GetExecutionResult()
        {
            return executionResult;
        }

        public void SetEssentialsClient(IRailwayDataEssentialsClient client)
        {
            this.essentialsClient = client;
        }

        public void SetRailway(RailwayDTO railway)
        {
            this.inputRailway = railway;
        }

        public void SetStationsClient(IRailwayDataStationsClient client)
        {
            this.stationsClient = client;
        }
    }
}
