namespace DatabaseAPI.Inner.Common.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public class Builder
        {
            private PhotoDTO item = new PhotoDTO();
            public Builder WithId(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder WithFilePath(string filePath)
            {
                item.FilePath = filePath;
                return this;
            }
            public PhotoDTO Build()
            {
                return item;
            }
        }
    }

}
