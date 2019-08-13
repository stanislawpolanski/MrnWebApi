namespace MrnWebApi.DataAccess.Inner.Scaffold
{
    public partial class RailwayUnits
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GeometriesId { get; set; }
        public int OwnerId { get; set; }

        public virtual Geometries Geometries { get; set; }
        public virtual Owners Owner { get; set; }
    }
}
