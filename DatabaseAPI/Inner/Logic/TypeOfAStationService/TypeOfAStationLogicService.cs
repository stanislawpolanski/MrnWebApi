using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.TypeOfAStation;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPI.Logic.TypeOfAStationService
{
    public class TypeOfAStationLogicService : ITypeOfAStationLogicService
    {
        private ITypeOfAStationDataAccessService service;

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
