using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Railway;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public class RailwayDataEssentialsClient : IRailwayDataEssentialsClient
    {
        private IRailwayDataAccessService service;
        public RailwayDataEssentialsClient(IRailwayDataAccessService service)
        {
            this.service = service;
        }
        public async Task<RailwayDTO> GetRailwayWithEssentialDataAsync(RailwayDTO railway)
        {
            return await service.GetRailwayByIdAsync(railway.Id);
        }
    }
}
