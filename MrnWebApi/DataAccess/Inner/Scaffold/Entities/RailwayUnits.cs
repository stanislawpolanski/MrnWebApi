namespace MrnWebApi.DataAccess.Inner.Scaffold.Entities
{
    public partial class RailwayUnits
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GeometriesId { get; set; }

        public virtual Geometries Geometries { get; set; }
    }
}
