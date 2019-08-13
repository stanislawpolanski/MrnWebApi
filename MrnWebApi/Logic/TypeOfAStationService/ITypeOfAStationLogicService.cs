using MrnWebApi.Common.DTOs;
using System.Collections.Generic;

namespace MrnWebApi.Logic.TypeOfAStationService
{
    public interface ITypeOfAStationLogicService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
