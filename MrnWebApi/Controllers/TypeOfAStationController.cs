using Microsoft.AspNetCore.Mvc;
using MrnWebApi.Common.Models;
using MrnWebApi.Logic.TypeOfAStationService;
using System.Collections.Generic;

namespace MrnWebApi.Controllers
{
    [Route(TYPE_OF_A_STATION_PATH)]
    [ApiController]
    public class TypeOfAStationController : ApiController
    {
        public const string TYPE_OF_A_STATION_PATH = API_PATH + "/type-of-a-station";

        private readonly ITypeOfAStationLogicService logicService;

        public TypeOfAStationController(ITypeOfAStationLogicService injectedService)
        {
            this.logicService = injectedService;
        }

        [HttpGet]
        public IEnumerable<TypeOfAStationModel> Get()
        {
            return logicService.GetTypesOfAStation();
        }
    }
}
