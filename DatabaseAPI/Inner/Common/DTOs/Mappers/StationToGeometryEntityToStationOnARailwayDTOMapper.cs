using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class StationToGeometryEntityToStationOnARailwayDTOMapper
    {
        public static StationOnARailwayDTO MapToDTO(
            StationsToGeometries entity)
        {
            return new StationOnARailwayDTO
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
