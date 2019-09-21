﻿using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.DTOs.FromEntitiesAdapters;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using DatabaseAPI.DataAccess.Services;
using DatabaseAPI.Inner.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.RollingStock
{
    public class DbRollingStockDataAccessService :
        DbDataAccessAbstractService,
        IRollingStockDataAccessService
    {
        public DbRollingStockDataAccessService(MRN_developContext injectedContext) : 
            base(injectedContext)
        {
        }

        public async Task<RollingStockDTO> GetRollingStockByIdAsync(int id)
        {
            ObjectsOfInterest entity = await GetObjectOfInterestEntityById(id);
            if (entity == null)
            {
                return null;
            }
            int stationCount = await GetCountStationEntityById(id);
            if (stationCount > 0)
            {
                return null;
            }
            RollingStockDTO dto = GetDTOByEntity(entity);
            return dto;
        }

        private static RollingStockDTO GetDTOByEntity(ObjectsOfInterest entity)
        {
            OwnerDTO owner = new OwnerEntityToOwnerDTOAdapter(entity.Owner);
            return new RollingStockDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .WithOwner(owner)
                .Build();
        }

        private async Task<int> GetCountStationEntityById(int id)
        {
            return await context
                .Stations
                .Where(row => row.Id.Equals(id))
                .CountAsync();
        }

        private async Task<ObjectsOfInterest> GetObjectOfInterestEntityById(int id)
        {
            return await context
                .ObjectsOfInterest
                .Include(row => row.Owner)
                .Where(row => row.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RollingStockDTO>> GetAllRollingStockAsync()
        {
            var dtos = await context
                .ObjectsOfInterest
                .Include(entity => entity.Stations)
                .Include(entity => entity.Owner)
                .Where(entity => entity.Stations == null)
                .Select(entity => GetDTOByEntity(entity))
                .ToListAsync();
            return dtos;
        }

        public async Task<RollingStockDTO> DeleteRollingStockAsync(RollingStockDTO dto)
        {
            int id = dto.Id;
            ObjectsOfInterest entity = await context.ObjectsOfInterest.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            context.ObjectsOfInterest.Remove(entity);
            await context.SaveChangesAsync();
            return new RollingStockDTO.Builder().WithId(id).Build();

        }

        public async Task<RollingStockDTO> PostRollingStockAsync(RollingStockDTO subject)
        {
            ObjectsOfInterest entity = AddEntityFromDTOToContext(subject);
            int entitiesWritten = await context.SaveChangesAsync();
            if (entitiesWritten == 0)
            {
                return null;
            }
            return GetDTOByEntity(entity);
        }

        private ObjectsOfInterest AddEntityFromDTOToContext(RollingStockDTO subject)
        {
            ObjectsOfInterest entity = new ObjectsOfInterest()
            {
                Name = subject.Name,
                OwnerId = subject.Owner.Id
            };
            context.ObjectsOfInterest.Add(entity);
            return entity;
        }
    }
}
