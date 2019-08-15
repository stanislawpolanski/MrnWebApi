using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Logic.TypeOfAStationService
{
    public interface ITypeOfAStationLogicService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
