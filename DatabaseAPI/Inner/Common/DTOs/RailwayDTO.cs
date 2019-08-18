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
            public Builder WithId(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder WithNumber(int number)
            {
                item.Number = number;
                return this;
            }
            public Builder WithName(string name)
            {
                item.Name = name;
                return this;
            }
            public Builder WithUrl(string url)
            {
                item.Url = url;
                return this;
            }
            public Builder WithOwner(OwnerDTO ownerDTO)
            {
                item.Owner = ownerDTO;
                return this;
            }
            public RailwayDTO Build()
            {
                return item;
            }
        }
    }
}