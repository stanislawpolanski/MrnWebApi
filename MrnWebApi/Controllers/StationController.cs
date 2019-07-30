using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrnWebApi.Common.Models;
using MrnWebApi.Common.Routing;
using MrnWebApi.Logic.StationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<StationModel> GetAllStations()
        {
            IEnumerable<StationModel> stations = stationLogicService.GetAllBasicStations();
            FillStationsWithUrls(stations);
            return stations;
        }

        private static void FillStationsWithUrls(IEnumerable<StationModel> stations)
        {
            stations
                .ToList()
                .ForEach(input => input.Url = UriRoute.GetRouteFromNodes(STATION_PATH, input.Id.ToString()).ToString());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StationModel>> GetStationByIdAsync(int id)
        {
            StationModel station = await stationLogicService.GetDetailedStationByIdAsync(id);
            if(station == null)
            {
                return NotFound();
            }
            FillRailwaysWithUrls(station);
            FillRailwayUnitWithUrl(station);
            return Ok(station);
        }

        private static void FillRailwayUnitWithUrl(StationModel station)
        {
            station.RailwayUnit.Url = UriRoute
                .GetRouteFromNodes(RailwayUnitController.RAILWAY_UNIT_PATH, station.RailwayUnit.Id .ToString())
                .ToString();
        }

        private static void FillRailwaysWithUrls(StationModel station)
        {
            station
                .Railways
                .ToList()
                .ForEach(railway =>
                    railway.Url = UriRoute.GetRouteFromNodes(RailwayController.RAILWAY_PATH,
                        railway.Id.ToString()).ToString());
        }

        [HttpPost]
        public void PostStation(StationModel inputStation)
        {
            stationLogicService.AddStation(inputStation);
        }

        [HttpPut("{id}")]
        public void PutStation(int id, [FromBody] StationModel inputStation)
        {
            stationLogicService.UpdateStation(inputStation);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stationLogicService.DeleteStationById(id);
        }
    }
}
