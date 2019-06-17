﻿using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace MrnWebApi.DataAccess.Inner.Scaffold
{
    public partial class Geometries
    {
        public Geometries()
        {
            Railways = new HashSet<Railways>();
            StationsToGeometries = new HashSet<StationsToGeometries>();
        }

        public int Id { get; set; }
        public IGeometry SpatialData { get; set; }

        public virtual RailwayUnits RailwayUnits { get; set; }
        public virtual ICollection<Railways> Railways { get; set; }
        public virtual ICollection<StationsToGeometries> StationsToGeometries { get; set; }
    }
}