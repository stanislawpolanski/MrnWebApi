namespace DatabaseAPI.Common.DTOs
{
    public class TypeOfAStationDTO
    {
        public int Id { get; set; }
        public string AbbreviatedName { get; set; }
        public class Builder
        {
            private TypeOfAStationDTO item = new TypeOfAStationDTO();
            public Builder Id(int id)
            {
                item.Id = id;
                return this;
            }
            public Builder AbbreviatedName(string abbreviatedName)
            {
                item.AbbreviatedName = abbreviatedName;
                return this;
            }
            public TypeOfAStationDTO Build()
            {
                return item;
            }
        }
    }
}