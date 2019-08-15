namespace DatabaseAPI.Common.DTOs
{
    public class RailwayUnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public class Builder
        {
            private RailwayUnitDTO item = new RailwayUnitDTO();
            public Builder Id(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder Name(string name)
            {
                item.Name = name;
                return this;
            }
            public Builder Url(string url)
            {
                item.Url = url;
                return this;
            }
            public RailwayUnitDTO Build()
            {
                return item;
            }
        }
    }
}