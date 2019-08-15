using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.DataAccess.Services.TypeOfAStation
{
    public interface ITypeOfAStationDataAccessService
    {
        ICollection<TypeOfAStationDTO> GetTypesOfAStation();
    }
}
