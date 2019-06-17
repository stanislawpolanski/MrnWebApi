using System;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Inner.Scaffold
{
    public partial class Owners
    {
        public Owners()
        {
            ObjectsOfInterest = new HashSet<ObjectsOfInterest>();
            RailwayUnits = new HashSet<RailwayUnits>();
            Railways = new HashSet<Railways>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ObjectsOfInterest> ObjectsOfInterest { get; set; }
        public virtual ICollection<RailwayUnits> RailwayUnits { get; set; }
        public virtual ICollection<Railways> Railways { get; set; }
    }
}
