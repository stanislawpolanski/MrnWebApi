using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class RailwayUnitMapper
    {
        public static RailwayUnitDTO MapToDTO(RailwayUnits entity)
        {
            return new RailwayUnitDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .Build();
        }
    }
}
