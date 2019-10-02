using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPI.Inner.DataAccess.Services.TypeOfAStation
{
    public class DbTypeOfAStationDataAccessService : 
        DbDataAccessAbstractService, 
        ITypeOfAStationDataAccessService
    {
        public DbTypeOfAStationDataAccessService(
            MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public ICollection<TypeOfAStationDTO> GetTypesOfAStation()
        {
            return context
                .TypesOfAstation
                .Select(entity => TypeOfAStationMapper.MapToDTO(entity))
                .ToList();
        }
    }
}
