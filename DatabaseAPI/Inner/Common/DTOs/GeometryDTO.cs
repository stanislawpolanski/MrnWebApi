using System;

namespace DatabaseAPI.Inner.Common.DTOs
{
    public class GeometryDTO
    {
        public int Id;
        public String SerialisedSpatialData;

        public class Builder
        {
            private GeometryDTO item = new GeometryDTO();
            public Builder WithId(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder WithSpatialData(string spatialData)
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
