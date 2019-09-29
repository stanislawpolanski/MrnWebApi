using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class RailwayUnitMapper
    {
        public static RailwayUnitDTO MapToDTO(RailwayUnits entity)
        {
            return new RailwayUnitDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .Build();
        }
    }
}
