using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using DatabaseAPI.Inner.Logic.StationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatabaseAPI.Controllers
{
    [Route(STATION_PATH)]
    [ApiController]
    public class StationController : DatabaseApiController
    {
        public const String STATION_PATH = DATABASE_ROOT_API_PATH + "/station";

        private readonly IStationLogicService stationLogicService;

        public StationController(IStationLogicService stationLogicService)
        {
            this.stationLogicService = stationLogicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDTO>>> GetAllStationsAsync()
        {
            IEnumerable<StationDTO> stations =
                await stationLogicService.GetAllBasicStationsAsync();
            FillStationsWithUrls(stations);
            return Ok(stations);
        }

        private static void
            FillStationsWithUrls(IEnumerable<StationDTO> collection)
        {
            foreach(var station in collection)
            {
                station.Url = UriRoute
                    .GetRouteStringFromNodes(STATION_PATH, station.Id.ToString());
            }
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
            if (station.RailwayUnit != null)
            {
                FillRailwayUnitWithUrl(station);
            }
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

        [HttpGet("railway/{railwayId}")]
        [ProducesResponseType(typeof(IEnumerable<StationOnARailwayLocationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StationOnARailwayLocationDTO>>> 
            GetStationsCollectionByRailwayIdAsync([FromRoute] int railwayId)
        {
            IEnumerable<StationOnARailwayLocationDTO> collection =
                await stationLogicService.GetStationsByRailwayIdAsync(railwayId);
            if (collection == null)
            {
                return NotFound();
            }
            FillStationsOnARailwayWithUrls(collection);
            return Ok(collection);
        }

        private static void
            FillStationsOnARailwayWithUrls(
            IEnumerable<StationOnARailwayLocationDTO> collection)
        {
            foreach (var station in collection)
            {
                station.Url = UriRoute.GetRouteStringFromNodes(
                    STATION_PATH, 
                    station.StationId.ToString());
            }
        }
    }
}
