using DatabaseAPI.Common.DTOs;
using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Single
{
    public class GetSingleRailwayCommand : AbstractSingleRailwayCommand
    {
        public override async Task ExecuteAsync()
        {

            executionResult = await essentialsClient
                .GetRailwayWithEssentialDataAsync(inputRailway);
            if(executionResult == null)
            {
                return;
            }
            executionResult.StationsKmPosts = await stationsClient
                .GetStationsLocationsOnARailway(inputRailway);
        }
    }
}
