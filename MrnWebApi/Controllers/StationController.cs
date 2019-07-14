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
        public IEnumerable<StationModel> Get()
        {
            IEnumerable<StationModel> stations = stationLogicService.GetBasicStations();
            FillStationsWithUrls(stations);
            return stations;
        }

        private static void FillStationsWithUrls(IEnumerable<StationModel> stations)
        {
            stations
                .ToList()
                .ForEach(input => input.Url = UriRoute.BuildRoute(STATION_PATH, input.Id.ToString()).ToString());
        }

        [HttpGet("{id}")]
        public StationModel Get(int id)
        {
            StationModel station = stationLogicService.GetDetailedStation(id);
            FillRailwaysWithUrls(station);
            FillRailwayUnitWithUrl(station);
            return station;
        }

        private static void FillRailwayUnitWithUrl(StationModel station)
        {
            station.RailwayUnit.Url = UriRoute.BuildRoute(RailwayUnitController.RAILWAY_UNIT_PATH,
                station.RailwayUnit.Id.ToString()).ToString();
        }

        private static void FillRailwaysWithUrls(StationModel station)
        {
            station
                .Railways
                .ToList()
                .ForEach(railway =>
                    railway.Url = UriRoute.BuildRoute(RailwayController.RAILWAY_PATH,
                        railway.Id.ToString()).ToString());
        }

        [HttpPost]
        public void PostStation(StationModel inputStation)
        {
            stationLogicService.AddStation(inputStation);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stationLogicService.DeleteStationById(id);
        }
    }
}
