using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.TypeOfAStation;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPI.Inner.Logic.TypeOfAStationService
{
    public class TypeOfAStationLogicService : ITypeOfAStationLogicService
    {
        private ITypeOfAStationDataAccessService service;

        public TypeOfAStationLogicService()
        {
        }

        public TypeOfAStationLogicService(
            ITypeOfAStationDataAccessService injectedService)
        {
            service = injectedService;
        }
        public ICollection<TypeOfAStationDTO> GetTypesOfAStation()
        {
            return service
                .GetTypesOfAStation()
                .OrderBy(typeOfAStation => typeOfAStation.AbbreviatedName)
                .ToList();
        }
    }
}
