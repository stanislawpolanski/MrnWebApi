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
        public class Builder
        {
            private StationDTO item = new StationDTO();
            public Builder WithId(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                item.Name = name;
                return this;
            }
            public Builder WithUrl(string url)
            {
                item.Url = url;
                return this;
            }
            public Builder WithGeometry(GeometryDTO geometryDTO)
            {
                item.SerialisedGeometry = geometryDTO;
                return this;
            }
            public Builder WithOwner(OwnerDTO ownerDTO)
            {
                item.OwnerInfo = ownerDTO;
                return this;
            }
            public Builder WithTypeOfAStation(TypeOfAStationDTO typeOfAStation)
            {
                item.TypeOfAStationInfo = typeOfAStation;
                return this;
            }
            public Builder WithRailwayUnit(RailwayUnitDTO railwayUnitDTO)
            {
                item.RailwayUnit = railwayUnitDTO;
                return this;
            }
            public StationDTO Build()
            {
                return item;
            }
        }
    }
}
