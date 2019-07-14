using GeoAPI.Geometries;
using System.Collections.Generic;

namespace MrnWebApi.Common.Models
{
    public class StationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public IGeometry LocationGeometry { get; set; }
        public OwnerModel OwnerInfo { get; set; }
        public TypeOfAStationModel TypeOfAStationInfo { get; set; }
        public RailwayUnitModel RailwayUnit { get; set; }
        public IEnumerable<PhotoModel> Photos { get; set; }
        public IEnumerable<RailwayModel> Railways { get; set; }
    }
}
