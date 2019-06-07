namespace MrnWebApi.Common.Models
{
    public class RailwayModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public OwnerModel Owner { get; set; }
    }
}