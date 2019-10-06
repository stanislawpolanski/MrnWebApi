using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Logic.TypeOfAStationService
{
    public interface ITypeOfAStationLogicService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
