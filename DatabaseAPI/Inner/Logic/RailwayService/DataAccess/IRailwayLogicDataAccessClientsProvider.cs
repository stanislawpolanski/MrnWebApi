using DatabaseAPI.Inner.Layers.Logic.RailwayService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccess
{
    public interface IRailwayLogicDataAccessClientsProvider
    {
        void InjectClients(IRailwayCommand command);
    }
}
