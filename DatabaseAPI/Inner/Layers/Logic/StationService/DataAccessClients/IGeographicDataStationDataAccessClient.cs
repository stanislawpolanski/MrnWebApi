﻿using DatabaseAPI.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices
{
    public interface IGeographicDataStationDataAccessClient
    {
        Task FillStationWithGeographicDataAsync(StationDTO station);
    }
}