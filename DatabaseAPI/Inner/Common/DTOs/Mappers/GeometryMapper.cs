using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

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
