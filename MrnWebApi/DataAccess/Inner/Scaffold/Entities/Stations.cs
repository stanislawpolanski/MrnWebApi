using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Inner.Scaffold.Entities
{
    public partial class Stations
    {
        public Stations()
        {
            StationsToGeometries = new HashSet<StationsToGeometries>();
        }

        public int Id { get; set; }
        public int? TypeOfAstationId { get; set; }

        public virtual ObjectsOfInterest IdNavigation { get; set; }
        public virtual TypesOfAstation TypeOfAstation { get; set; }
        public virtual ICollection<StationsToGeometries> StationsToGeometries { get; set; }
    }
}
