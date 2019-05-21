using System;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Inner.Scaffold.Entities
{
    public partial class TypesOfAstation
    {
        public TypesOfAstation()
        {
            Stations = new HashSet<Stations>();
        }

        public int Id { get; set; }
        public string AbbreviatedName { get; set; }

        public virtual ICollection<Stations> Stations { get; set; }
    }
}
