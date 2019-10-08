namespace DatabaseAPI.Inner.Common.DTOs
{
    public class StationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public GeometryDTO SerialisedGeometry { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
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
            public Builder WithOwnerId(int ownerId)
            {
                item.OwnerId = ownerId;
                return this;
            }
            public Builder WithOwnerName(string ownerName)
            {
                item.OwnerName = ownerName;
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
