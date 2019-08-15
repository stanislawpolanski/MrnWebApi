using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Common.DTOs.FromEntitiesAdapters
{
    public class GeometryEntityToGeometryDTOAdapter : GeometryDTO
    {
        public GeometryEntityToGeometryDTOAdapter(Geometries adaptee)
        {
            this.Id = adaptee.Id;
            this.SerialisedSpatialData = adaptee.SpatialData.ToString();
        }
    }
}