using DatabaseAPI.Common.DTOs;
using System;
using System.Collections.Generic;

namespace DatabaseAPI.Inner.Common.DTOs
{
    public class RollingStockDTO
    {
        public int Id;
        public string Name;
        public string Url;
        public OwnerDTO Owner;

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

            public Builder WithUrl(string url)
            {
                item.Url = url;
                return this;
            }

            public Builder WithOwner(OwnerDTO owner)
            {
                item.Owner = owner;
                return this;
            }

            public RollingStockDTO Build()
            {
                return item;
            }
        }
    }
}
