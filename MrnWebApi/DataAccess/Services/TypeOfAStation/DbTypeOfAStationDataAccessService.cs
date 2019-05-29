using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.TypeOfAStation
{
    public class DbTypeOfAStationDataAccessService : DatabaseDataAccessService, ITypeOfAStationDataAccessService
    {
        public DbTypeOfAStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public ICollection<TypeOfAStationModel> GetTypesOfAStation()
        {
            return dbContext.TypesOfAstation
                .Select(stationType =>
                    new TypeOfAStationModel
                    {
                        Id = stationType.Id,
                        AbbreviatedName = stationType.AbbreviatedName
                    })
                .ToList();
        }
    }
}
