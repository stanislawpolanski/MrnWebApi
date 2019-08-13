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
    }
}
