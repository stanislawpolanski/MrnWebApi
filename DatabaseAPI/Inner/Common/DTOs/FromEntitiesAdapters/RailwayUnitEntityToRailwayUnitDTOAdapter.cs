using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class RailwayUnitEntityToRailwayUnitDTOAdapter : RailwayUnitDTO
    {
        public RailwayUnitEntityToRailwayUnitDTOAdapter(RailwayUnits adaptee)
        {
            this.Id = adaptee.Id;
            this.Name = adaptee.Name;
        }
    }
}
