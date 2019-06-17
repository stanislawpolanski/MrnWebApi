﻿using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.TypeOfAStation;
using System.Collections.Generic;
using System.Linq;

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