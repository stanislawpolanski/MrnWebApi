using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class GeometryEntityToGeometryDTOAdapter : GeometryDTO
    {
        public GeometryEntityToGeometryDTOAdapter(Geometries adaptee)
        {
            this.Id = adaptee.Id;
            this.SerialisedSpatialData = adaptee.SpatialData.ToString();
        }
    }
}