using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.DTOs
{
    public class StationOnARailwayLocationDTO
    {
        public int StationId;
        public string Name;
        public decimal? BeginningKmPost;
        public decimal CentreKmPost;
        public decimal? EndingKmPost;

        public class Builder
        {
            private StationOnARailwayLocationDTO item = 
                new StationOnARailwayLocationDTO();

            public Builder WithStationId(int id)
            {
                item.StationId = id;
                return this;
            }

            public Builder WithName(string name)
            {
                item.Name = name;
                return this;
            }

            public Builder WithKmPosts(decimal? beginning, decimal centre, decimal? ending)
            {
                item.BeginningKmPost = beginning;
                item.CentreKmPost = centre;
                item.EndingKmPost = ending;
                return this;
            }

            public StationOnARailwayLocationDTO Build()
            {
                return item;
            }
        }
    }
}
