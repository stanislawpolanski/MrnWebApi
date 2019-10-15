using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class StationToGeometryEntityToStationOnARailwayDTOMapper
    {
        public static StationOnARailwayLocationDTO MapToDTO(
            StationsToGeometries entity)
        {
            return new StationOnARailwayLocationDTO
                .Builder()
                .WithStationId(entity.StationId)
                .WithName(entity.Station.ParentObjectOfInterest.Name)
                .WithKmPosts(
                    entity.BeginningKmpost, 
                    entity.CentreKmpost, 
                    entity.EndingKmpost)
                .Build();
        }
    }
}
