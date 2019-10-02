using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    internal static class TypeOfAStationMapper
    {
        internal static TypeOfAStationDTO MapToDTO(TypesOfAstation entity)
        {
            return new TypeOfAStationDTO
                .Builder()
                .WithId(entity.Id)
                .WithAbbreviatedName(entity.AbbreviatedName)
                .Build();
        }
    }
}
