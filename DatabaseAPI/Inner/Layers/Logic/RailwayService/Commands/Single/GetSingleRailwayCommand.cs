using DatabaseAPI.Common.DTOs;
using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single
{
    public class GetSingleRailwayCommand : AbstractSingleRailwayCommand
    {
        public override async Task ExecuteAsync()
        {
            RailwayDTO outcomeRailway = 
                await essentialsClient.GetRailwayWithEssentialDataAsync(railway);
            railway.Name = outcomeRailway.Name;
            railway.Number = outcomeRailway.Number;
            railway.Owner = outcomeRailway.Owner;
            railway.StationsKmPosts = 
                await stationsClient.GetStationsLocationsOnARailway(railway);
        }
    }
}
