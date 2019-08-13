using System;

namespace DatabaseAPI.Common.DTOs
{
    public class GeometryDTO
    {
        public int Id;
        public String SerialisedSpatialData;

        public class Builder
        {
            private GeometryDTO item = new GeometryDTO();
            public Builder Id(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder SpatialData(string spatialData)
            {
                item.SerialisedSpatialData = spatialData;
                return this;
            }
            public GeometryDTO Build()
            {
                return this.item;
            }
        }
    }
}
