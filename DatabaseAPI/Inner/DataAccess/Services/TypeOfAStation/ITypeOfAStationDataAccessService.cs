using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.DataAccess.Services.TypeOfAStation
{
    public interface ITypeOfAStationDataAccessService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
