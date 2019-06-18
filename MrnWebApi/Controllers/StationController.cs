using Microsoft.AspNetCore.Mvc;
using MrnWebApi.Common.Models;
using MrnWebApi.Common.Routing;
using MrnWebApi.Logic.StationService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.Controllers
{
    [Route(STATION_PATH)]
    [ApiController]
    public class StationController : ApiController
    {
        public const String STATION_PATH = API_PATH + "/station";

        private readonly IStationLogicService stationLogicService;

        public StationController(IStationLogicService stationLogicService)
        {
            this.stationLogicService = stationLogicService;
        }

        [HttpGet]
        public IEnumerable<StationModel> Get()
        {
            return stationLogicService
                .GetBasicStations()
                .ToList()
                .Select(input =>
                {
                    input.Url = UriRoute.BuildRoute(STATION_PATH, input.Id.ToString()).ToString();
                    return input;
                });
        }

        [HttpGet("{id}")]
        public StationModel Get(int id)
        {
            StationModel station = stationLogicService.GetDetailedStation(id);

            station
                .Railways
                .ToList()
                .ForEach(railway => 
                    railway.Url = UriRoute.BuildRoute(RailwayController.RAILWAY_PATH, 
                        railway.Id.ToString()).ToString());

            station.RailwayUnit.Url = UriRoute.BuildRoute(RailwayUnitController.RAILWAY_UNIT_PATH, 
                station.RailwayUnit.Id.ToString()).ToString();

            return station;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
