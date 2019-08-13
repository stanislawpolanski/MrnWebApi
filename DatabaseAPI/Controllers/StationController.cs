using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.Routing;
using DatabaseAPI.Logic.StationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Controllers
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
        public async Task<IEnumerable<StationDTO>> GetAllStations()
        {
            IEnumerable<StationDTO> stations =
                await stationLogicService.GetAllBasicStationsAsync();
            FillStationsWithUrls(stations);
            return stations;
        }

        private static void
            FillStationsWithUrls(IEnumerable<StationDTO> stations)
        {
            Action<StationDTO> setStationUrl =
                input =>
                input.Url =
                    UriRoute
                    .GetRouteFromNodes(
                        STATION_PATH,
                        input.Id.ToString())
                    .ToString();
            stations.ToList().ForEach(setStationUrl);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StationDTO>>
            GetStationByIdAsync(int id)
        {
            StationDTO station =
                await stationLogicService.GetStationByIdAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            FillRailwaysWithUrls(station);
            FillRailwayUnitWithUrl(station);
            return Ok(station);
        }

        private static void FillRailwayUnitWithUrl(StationDTO station)
        {
            station.RailwayUnit.Url = UriRoute
                .GetRouteFromNodes(
                    RailwayUnitController.RAILWAY_UNIT_PATH,
                    station.RailwayUnit.Id.ToString())
                .ToString();
        }

        private static void FillRailwaysWithUrls(StationDTO station)
        {
            Action<RailwayDTO> setRailwayUrl =
                railway =>
                railway.Url =
                    UriRoute
                    .GetRouteFromNodes(
                        RailwayController.RAILWAY_PATH,
                        railway.Id.ToString()).ToString();
            station.Railways.ToList().ForEach(setRailwayUrl);
        }

        [HttpPost]
        public async Task<ActionResult<StationDTO>>
            PostStationAsync(StationDTO inputStation)
        {
            await stationLogicService.PostStationAsync(inputStation);
            return inputStation;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult>
            PutStation(int id, [FromBody] StationDTO inputStation)
        {
            if (id != inputStation.Id)
            {
                return BadRequest();
            }
            await stationLogicService.PutStationAsync(inputStation);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await stationLogicService.DeleteStationByIdAsync(id);
        }
    }
}
