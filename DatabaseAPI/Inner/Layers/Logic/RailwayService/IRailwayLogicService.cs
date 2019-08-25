using DatabaseAPI.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService
{
    public interface IRailwayLogicService
    {
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
    }
}
