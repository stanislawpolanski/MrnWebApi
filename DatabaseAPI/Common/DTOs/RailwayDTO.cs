namespace DatabaseAPI.Common.DTOs
{
    public class RailwayDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public OwnerDTO Owner { get; set; }
        public class Builder
        {
            private RailwayDTO item = new RailwayDTO();
            public Builder Id(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder Number(int number)
            {
                item.Number = number;
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
            public Builder Owner(OwnerDTO owner)
            {
                item.Owner = owner;
                return this;
            }
            public RailwayDTO Build()
            {
                return item;
            }
        }
    }
}