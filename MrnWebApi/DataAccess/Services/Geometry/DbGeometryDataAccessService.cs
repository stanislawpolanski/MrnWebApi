using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Geometry
{
    public class DbGeometryDataAccessService : DbDataAccessAbstractService, IGeometryDataAccessService
    {
        public DbGeometryDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task<GeometryModel> GetFirstGeometryByStationIdAsync(int id)
        {
            return await context
                .StationsToGeometries
                .Where(relation => relation.StationId.Equals(id))
                .Include(relation => relation.Geometry)
                .Select(entity =>
                    new GeometryModel()
                    {
                        Id = entity.Geometry.Id,
                        SerialisedSpatialData = entity.Geometry.SpatialData.ToString()
                    })
                .FirstOrDefaultAsync();
        }
    }
}
