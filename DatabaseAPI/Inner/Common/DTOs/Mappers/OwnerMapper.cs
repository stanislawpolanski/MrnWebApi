using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;

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

        public static Owners MapToEntity(OwnerDTO dto)
        {
            Owners entity = new Owners();
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            return entity;
        }
    }
}
