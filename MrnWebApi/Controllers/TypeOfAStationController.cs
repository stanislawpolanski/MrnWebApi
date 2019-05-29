using Microsoft.AspNetCore.Mvc;
using MrnWebApi.Common.Models;
using MrnWebApi.Logic.TypeOfAStationService;
using System.Collections.Generic;

namespace MrnWebApi.Controllers
{
    [Route(TypeOfAStationController.TYPE_OF_A_STATION_PATH)]
    [ApiController]
    public class TypeOfAStationController : ControllerBase
    {
        public const string TYPE_OF_A_STATION_PATH = "/api/type-of-a-station";

        private readonly ITypeOfAStationLogicService logicService;

        public TypeOfAStationController(ITypeOfAStationLogicService injectedService)
        {
            this.logicService = injectedService;
        }

        // GET: /api/type-of-a-station
        [HttpGet]
        public IEnumerable<TypeOfAStationModel> Get()
        {
            return logicService.GetTypesOfAStation();
        }
    }
}
