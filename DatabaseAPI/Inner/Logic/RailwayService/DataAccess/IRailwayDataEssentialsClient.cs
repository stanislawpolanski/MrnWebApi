using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RailwayService.DataAccess
{
    public interface IRailwayDataEssentialsClient
    {
        Task<RailwayDTO> GetRailwayWithEssentialDataAsync(RailwayDTO railway);
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
    }
}
