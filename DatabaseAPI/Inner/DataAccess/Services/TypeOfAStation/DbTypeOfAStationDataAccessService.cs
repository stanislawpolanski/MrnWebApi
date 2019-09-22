using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseAPI.DataAccess.Services.TypeOfAStation
{
    public class DbTypeOfAStationDataAccessService : DbDataAccessAbstractService, ITypeOfAStationDataAccessService
    {
        public DbTypeOfAStationDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public ICollection<TypeOfAStationDTO> GetTypesOfAStation()
        {
            Expression<System.Func<TypesOfAstation, TypeOfAStationDTO>>
                selectToDTO = stationType =>
                new TypeOfAStationDTO
                {
                    Id = stationType.Id,
                    AbbreviatedName = stationType.AbbreviatedName
                };
            return context.TypesOfAstation
                .Select(selectToDTO)
                .ToList();
        }
    }
}
