using DatabaseAPI.Inner.Common.Command;
using DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands
{
    public interface IRailwayCommand : ICommand
    {
        void SetEssentialsClient(IRailwayDataEssentialsClient client);
    }
}
