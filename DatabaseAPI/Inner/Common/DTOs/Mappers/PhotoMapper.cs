using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
