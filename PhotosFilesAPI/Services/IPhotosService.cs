using System.Collections.Generic;

namespace PhotosFilesAPI.Services
{
    public interface IPhotosService
    {
       IEnumerable<string> GetPhotosList();
    }
}
