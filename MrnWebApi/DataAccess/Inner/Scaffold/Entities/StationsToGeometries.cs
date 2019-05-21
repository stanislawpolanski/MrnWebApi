using System;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Inner.Scaffold.Entities
{
    public partial class StationsToGeometries
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public int? GeometryId { get; set; }
        public decimal? BeginningKmpost { get; set; }
        public decimal CentreKmpost { get; set; }
        public decimal? EndingKmpost { get; set; }
        public int RailwayId { get; set; }

        public virtual Geometries Geometry { get; set; }
        public virtual Railways Railway { get; set; }
        public virtual Stations Station { get; set; }
    }
}
