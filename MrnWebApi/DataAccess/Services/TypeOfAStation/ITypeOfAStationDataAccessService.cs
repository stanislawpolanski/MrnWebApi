using MrnWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.TypeOfAStation
{
    public interface ITypeOfAStationDataAccessService
    {
        ICollection<TypeOfAStationModel> GetTypesOfAStation();
    }
}
