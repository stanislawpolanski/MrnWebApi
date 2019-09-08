using DatabaseAPI.Common.DTOs;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Common.DTOs
{
    public class RollingStockDTO
    {
        public int Id;
        public string Name;
        public OwnerDTO Owner;
        public IEnumerable<PhotoDTO> Photos;

        public class Builder
        {
            private RollingStockDTO item = new RollingStockDTO();

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

            public Builder WithOwner(OwnerDTO owner)
            {
                item.Owner = owner;
                return this;
            }

            public Builder WithPhotos(IEnumerable<PhotoDTO> photos)
            {
                item.Photos = photos;
                return this;
            }

            public RollingStockDTO Build()
            {
                return item;
            }
        }
    }
}
