using DatabaseAPI.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public interface IRailwayDataEssentialsClient
    {
        Task<RailwayDTO> GetRailwayWithEssentialDataAsync(RailwayDTO railway);
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
    }
}
