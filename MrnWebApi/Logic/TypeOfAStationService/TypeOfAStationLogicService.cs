using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.TypeOfAStation;

namespace MrnWebApi.Logic.TypeOfAStationService
{
    public class TypeOfAStationLogicService : ITypeOfAStationLogicService
    {
        private ITypeOfAStationDataAccessService service;

        public TypeOfAStationLogicService(ITypeOfAStationDataAccessService injectedService)
        {
            service = injectedService;
        }
        public ICollection<TypeOfAStationModel> GetTypesOfAStation()
        {
            return service.GetTypesOfAStation().OrderBy(typeOfAStation => typeOfAStation.AbbreviatedName).ToList();
        }
    }
}
