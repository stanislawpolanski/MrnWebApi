using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public interface IRailwayDataEssentialsClient
    {
        Task<RailwayDTO> GetRailwayWithEssentialDataAsync(RailwayDTO railway);
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
    }
}
