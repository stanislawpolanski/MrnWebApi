using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class OwnerMapper
    {
        public static OwnerDTO MapToDTO(Owners entity)
        {
            return new OwnerDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .Build();
        }
    }
}
