using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Logic.RailwayService.Commands.Collection
{
    public interface ICollectionOfRailwayCommand : IRailwayCommand
    {
        IEnumerable<RailwayDTO> GetExecutionResult();
    }
}
