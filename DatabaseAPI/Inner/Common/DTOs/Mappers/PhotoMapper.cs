using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;

namespace DatabaseAPI.Inner.Common.DTOs.Mappers
{
    public static class PhotoMapper
    {
        public static PhotoDTO MapToDTO(Photos entity)
        {
            return new PhotoDTO
                .Builder()
                .WithId(entity.Id)
                .WithFilePath(entity.FilePath)
                .Build();
        }
    }
}
