using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.TypeOfAStationService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatabaseAPI.Controllers
{
    [Route(TYPE_OF_A_STATION_PATH)]
    [ApiController]
    public class TypeOfAStationController : DatabaseApiController
    {
        public const string TYPE_OF_A_STATION_PATH = DATABASE_ROOT_API_PATH + "/type-of-a-station";

        private readonly ITypeOfAStationLogicService logicService;

        public TypeOfAStationController(ITypeOfAStationLogicService injectedService)
        {
            this.logicService = injectedService;
        }

        [HttpGet]
        public IEnumerable<TypeOfAStationDTO> Get()
        {
            return logicService.GetTypesOfAStation();
        }
    }
}
