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
            var entity = await context
                .ObjectsOfInterest
                .Where(row => row.Id.Equals(id))
                .FirstOrDefaultAsync();

            RollingStockDTO dto = new RollingStockDTO
                .Builder()
                .WithId(entity.Id)
                .WithName(entity.Name)
                .Build();

            return dto;
        }
    }
}
