using System.ComponentModel.DataAnnotations;

namespace DatabaseAPI.Inner.Common.DTOs
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
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