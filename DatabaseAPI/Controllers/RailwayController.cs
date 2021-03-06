﻿using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using DatabaseAPI.Inner.Logic.RailwayService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Controllers
{
    [Route(RAILWAY_PATH)]
    [ApiController]
    public class RailwayController : DatabaseApiController
    {
        public const String RAILWAY_PATH = DATABASE_ROOT_API_PATH + "/railway";

        private IRailwayLogicService service;

        public RailwayController(IRailwayLogicService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RailwayDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RailwayDTO>>> GetAllRailwaysAsync()
        {
            IEnumerable<RailwayDTO> railways = await service.GetAllRailwaysAsync();
            FillWithUrls(railways);
            return Ok(railways);
        }

        private void FillWithUrls(IEnumerable<RailwayDTO> railways)
        {
            Action<RailwayDTO> addUrlFromId = railway =>
                railway.Url = UriRoute
                    .GetRouteStringFromNodes(RAILWAY_PATH, railway.Id.ToString());
            railways
                .ToList()
                .ForEach(addUrlFromId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RailwayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RailwayDTO>> Get(int id)
        {
            RailwayDTO railway = await service.GetRailwayById(id);
            if (railway == null)
            {
                return NotFound();
            }
            return Ok(railway);
        }
    }
}
