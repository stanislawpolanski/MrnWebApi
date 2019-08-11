using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.TypeOfAStation
{
    public class DbTypeOfAStationDataAccessService : DbDataAccessAbstractService, ITypeOfAStationDataAccessService
    {
        public DbTypeOfAStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public ICollection<TypeOfAStationDTO> GetTypesOfAStation()
        {
            return context.TypesOfAstation
                //todo to be refactored to dto builder
                .Select(stationType =>
                    new TypeOfAStationDTO
                    {
                        Id = stationType.Id,
                        AbbreviatedName = stationType.AbbreviatedName
                    })
                .ToList();
        }
    }
}
