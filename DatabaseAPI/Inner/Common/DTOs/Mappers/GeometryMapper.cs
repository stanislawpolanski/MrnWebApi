using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class GeometryMapper
    {
        public static GeometryDTO MapToDTO(Geometries entity)
        {
            return new GeometryDTO
                .Builder()
                .WithId(entity.Id)
                .WithSpatialData(entity.SpatialData.ToString())
                .Build();
        }
    }
}
