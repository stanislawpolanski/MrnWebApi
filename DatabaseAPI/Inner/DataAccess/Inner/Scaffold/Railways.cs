using System.Collections.Generic;

namespace DatabaseAPI.Inner.DataAccess.Inner.Scaffold
{
    public partial class Railways
    {
        public Railways()
        {
            StationsToGeometries = new HashSet<StationsToGeometries>();
        }

        public int Id { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int? GeometryId { get; set; }

        public virtual Geometries Geometry { get; set; }
        public virtual Owners Owner { get; set; }
        public virtual ICollection<StationsToGeometries> StationsToGeometries { get; set; }
    }
}
