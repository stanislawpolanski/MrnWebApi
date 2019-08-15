using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
