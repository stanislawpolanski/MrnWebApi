namespace DatabaseAPI.Inner.Common.DTOs
{
    public class OwnerDTO
    {
        public int Id;
        public string Name;
        public string Url;
        public class Builder
        {
            private OwnerDTO item = new OwnerDTO();
            public Builder WithId(int id)
            {
                item.Id = id;
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

            public OwnerDTO Build()
            {
                return item;
            }
        }
    }
}