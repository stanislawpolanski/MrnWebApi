﻿using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Railway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public class RailwayDataEssentialsClient : IRailwayDataEssentialsClient
    {
        private IRailwayDataAccessService service;
        public RailwayDataEssentialsClient(IRailwayDataAccessService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<RailwayDTO>> GetAllRailwaysAsync()
        {
            IEnumerable<RailwayDTO> railways = await service.GetAllRailwaysAsync();
            return railways;
        }

        public async Task<RailwayDTO> GetRailwayWithEssentialDataAsync(RailwayDTO railway)
        {
            return await service.GetRailwayByIdAsync(railway.Id);
        }
    }
}
