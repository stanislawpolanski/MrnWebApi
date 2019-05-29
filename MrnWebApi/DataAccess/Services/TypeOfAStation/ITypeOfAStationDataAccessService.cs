using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.TypeOfAStation
{
    public interface ITypeOfAStationDataAccessService
    {
        ICollection<TypeOfAStationModel> GetTypesOfAStation();
    }
}
