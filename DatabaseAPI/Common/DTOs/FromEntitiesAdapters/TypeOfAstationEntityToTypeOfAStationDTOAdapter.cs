using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class TypeOfAstationEntityToTypeOfAStationDTOAdapter : 
        TypeOfAStationDTO
    {
        public TypeOfAstationEntityToTypeOfAStationDTOAdapter(
            TypesOfAstation adaptee)
        {
            this.Id = adaptee.Id;
            this.AbbreviatedName = adaptee.AbbreviatedName;
        }
    }
}
