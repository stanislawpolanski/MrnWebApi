using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    internal static class ObjectOfInterestToStationMapper
    {
        internal static ObjectsOfInterest MapToEntity(StationDTO station)
        {
            ObjectsOfInterest result = new ObjectsOfInterest();
            result.Name = station.Name;
            result.OwnerId = station.OwnerInfo.Id;
            return result;
        }
    }
}
