namespace DatabaseAPI.Inner.Common.DTOs
{
    public class StationOnARailwayDTO
    {
        public int StationId;
        public string Name;
        public string Url;
        public decimal? BeginningKmPost;
        public decimal CentreKmPost;
        public decimal? EndingKmPost;

        public class Builder
        {
            private StationOnARailwayDTO item =
                new StationOnARailwayDTO();

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

            public Builder WitUrl(string url)
            {
                item.Url = url;
                return this;
            }

            public Builder WithKmPosts(decimal? beginning, decimal centre, decimal? ending)
            {
                item.BeginningKmPost = beginning;
                item.CentreKmPost = centre;
                item.EndingKmPost = ending;
                return this;
            }

            public StationOnARailwayDTO Build()
            {
                return item;
            }
        }
    }
}
