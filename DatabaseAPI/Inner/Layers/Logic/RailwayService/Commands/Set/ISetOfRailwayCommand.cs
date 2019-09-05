using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands.Set
{
    public interface ISetOfRailwayCommand : IRailwayCommand
    {
        IEnumerable<RailwayDTO> GetExecutionResult();
    }
}
