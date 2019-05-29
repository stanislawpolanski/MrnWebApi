using Microsoft.AspNetCore.Mvc;
using MrnWebApi.Common.Models;
using MrnWebApi.Logic.StationService;
using System;
using System.Collections.Generic;
using System.Linq;
using MrnWebApi.Common.Routing;

namespace MrnWebApi.Controllers
{
    [Route(StationController.STATION_PATH)]
    [ApiController]
    public class StationController : ControllerBase
    {
        public const String STATION_PATH = "/api/station";

        private readonly IStationLogicService stationLogicService;

        public StationController(IStationLogicService stationLogicService)
        {
            this.stationLogicService = stationLogicService;
        }

        // GET api/values
        [HttpGet]
        public ICollection<BasicStationControllerModel> Get()
        {
            List<BasicStationModel> inputModels = stationLogicService.GetBasicStations().ToList();
            List<BasicStationControllerModel> outputModels = new List<BasicStationControllerModel>();

            inputModels.ForEach(input => outputModels.Add(
                new BasicStationControllerModel() {
                    Id = input.Id,
                    Name = input.Name,
                    Url = UriRoute.BuildRoute(STATION_PATH, input.Id.ToString()).ToString() }));

            return outputModels;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
