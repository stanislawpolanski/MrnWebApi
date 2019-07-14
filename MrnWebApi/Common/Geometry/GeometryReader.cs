using GeoAPI.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Common.Geometry
{
    public class GeometryReader
    {
        public IGeometry GetGeometryFromText(String text)
        {
            WKTReader reader = new WKTReader();
            return reader.Read(text);
        }
    }
}
