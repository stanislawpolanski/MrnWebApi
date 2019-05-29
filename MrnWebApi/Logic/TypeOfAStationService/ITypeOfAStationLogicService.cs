using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.Logic.TypeOfAStationService
{
    public interface ITypeOfAStationLogicService
    {
        ICollection<TypeOfAStationModel> GetTypesOfAStation();
    }
}
