using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    internal static class ObjectOfInterestToStationMapper
    {
        internal static ObjectsOfInterest MapToEntity(StationDTO station)
        {
            ObjectsOfInterest result = new ObjectsOfInterest();
            result.Name = station.Name;
            result.OwnerId = station.OwnerId;
            return result;
        }
    }
}
