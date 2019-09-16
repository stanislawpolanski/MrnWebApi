using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService
{
    public interface IRailwayLogicService
    {
        Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync();
        Task<RailwayDTO> GetRailwayById(int id);
    }
}
