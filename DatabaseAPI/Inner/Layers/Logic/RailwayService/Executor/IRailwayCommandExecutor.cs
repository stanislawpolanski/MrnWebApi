using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Executor
{
    public interface IRailwayCommandExecutor
    {
        Task ExecuteCommand(IRailwayCommand command);
    }
}
