namespace DatabaseAPI.Common.DTOs
{
    public class TypeOfAStationDTO
    {
        public int Id { get; set; }
        public string AbbreviatedName { get; set; }
        public class Builder
        {
            private TypeOfAStationDTO item = new TypeOfAStationDTO();
            public Builder Id(id)
            {
                item.Id = id;
                return this;
            }
            public Builder AbbreviatedName(abbreviatedname)
            {
                item.AbbreviatedName = abbreviatedname;
                return this;
            }
            public TypeOfAStationDTO Build()
            {
                return item;
            }
        }
    }
}