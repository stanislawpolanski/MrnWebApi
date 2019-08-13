using System.Collections.Generic;

namespace DatabaseAPI.Common.DTOs
{
    public class StationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public GeometryDTO SerialisedGeometry { get; set; }
        public OwnerDTO OwnerInfo { get; set; }
        public TypeOfAStationDTO TypeOfAStationInfo { get; set; }
        public RailwayUnitDTO RailwayUnit { get; set; }
        public IEnumerable<PhotoDTO> Photos { get; set; }
        public IEnumerable<RailwayDTO> Railways { get; set; }
        public class Builder
        {
            private StationDTO item = new StationDTO();
            public Builder Id(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder Name(string name)
            {
                item.Name = name;
                return this;
            }
            public Builder Url(string url)
            {
                item.Url = url;
                return this;
            }
            public Builder Geometry(GeometryDTO serialisedgeometry)
            {
                item.SerialisedGeometry = serialisedgeometry;
                return this;
            }
            public Builder Owner(OwnerDTO ownerinfo)
            {
                item.OwnerInfo = ownerinfo;
                return this;
            }
            public Builder TypeOfAStation(TypeOfAStationDTO typeofastationinfo)
            {
                item.TypeOfAStationInfo = typeofastationinfo;
                return this;
            }
            public Builder RailwayUnit(RailwayUnitDTO railwayunit)
            {
                item.RailwayUnit = railwayunit;
                return this;
            }
            public Builder Photos(IEnumerable<PhotoDTO> photos)
            {
                item.Photos = photos;
                return this;
            }
            public Builder Railways(IEnumerable<RailwayDTO> railways)
            {
                item.Railways = railways;
                return this;
            }
            public StationDTO Build()
            {
                return item;
            }
        }
    }
}
