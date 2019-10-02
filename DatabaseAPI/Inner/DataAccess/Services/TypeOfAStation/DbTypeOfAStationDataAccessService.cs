using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.Inner.Common.DTOs.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseAPI.DataAccess.Services.TypeOfAStation
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
