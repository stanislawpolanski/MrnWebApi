namespace DatabaseAPI.Common.DTOs
{
    public class OwnerDTO
    {
        public int Id;
        public string Name;
    }
    public class Builder
    {
        private OwnerDTO item = new OwnerDTO();
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
        public OwnerDTO Build()
        {
            return item;
        }

    }
}