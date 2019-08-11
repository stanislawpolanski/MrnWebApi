namespace MrnWebApi.Common.Models
{
    public class RailwayDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}