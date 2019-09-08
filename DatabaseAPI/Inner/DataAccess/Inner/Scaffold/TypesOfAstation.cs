using System.Collections.Generic;

namespace DatabaseAPI.DataAccess.Inner.Scaffold
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
