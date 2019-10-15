using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using DatabaseAPI.Inner.DataAccess.Services.Station.Subservices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Station
{
    public class DbStationDataAccessService : 
        DbDataAccessAbstractService,
        IStationDataAccessService
    {
        private GetStationDataAccessService getService;
        private ManipulateStationDataAccessService manipulateService;

        public DbStationDataAccessService(MRN_developContext context) :
            base(context)
        {
            getService = new GetStationDataAccessService(context);
            manipulateService = new ManipulateStationDataAccessService(context);
        }

        public async Task PostStationAsync(StationDTO inputStation)
        {
            await manipulateService.PostStationAsync(inputStation);
        }

        public async Task DeleteStationByIdAsync(int id)
        {
            await manipulateService.DeleteStationByIdAsync(id);
        }

        public async Task<IEnumerable<StationDTO>> GetBasicStationsAsync()
        {
            return await getService.GetBasicStationsAsync();
        }

        public async Task<StationDTO> GetDetailedStationAsync(int id)
        {
            return await getService.GetDetailedStationAsync(id);
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            await manipulateService.PutStationAsync(inputStation);
        }

        public async Task<IEnumerable<StationOnARailwayDTO>>
            GetStationsLocationsByRailwayAsync(RailwayDTO railway)
        {
            return await getService.GetStationsLocationsByRailwayAsync(railway);
        }

        public async Task<IEnumerable<StationOnARailwayDTO>>
            GetStationsByRailwayIdAsync(int railwayId)
        {
            return await getService.GetStationsByRailwayIdAsync(railwayId);
        }
    }
}
