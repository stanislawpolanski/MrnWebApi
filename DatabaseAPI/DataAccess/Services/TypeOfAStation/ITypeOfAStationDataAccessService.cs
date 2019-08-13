using MrnWebApi.Common.DTOs;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.TypeOfAStation
{
    public interface ITypeOfAStationDataAccessService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
