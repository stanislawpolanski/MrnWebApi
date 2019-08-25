using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Layers.Logic.RailwayService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DatabaseAPI.Common.Routing;

namespace DatabaseAPI.Controllers
{
    [Route(RAILWAY_PATH)]
    [ApiController]
    public class RailwayController : ApiController
    {
        public const String RAILWAY_PATH = API_PATH + "/railway";

        private IRailwayLogicService service;

        public RailwayController(IRailwayLogicService service)
        {
            this.service = service;
        }

        [HttpGet]
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
        public string Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
