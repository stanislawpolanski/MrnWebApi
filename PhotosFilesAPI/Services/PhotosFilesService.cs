using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotosFilesAPI.Services
{
    public class PhotosFilesService : IPhotosService
    {
        private IConfiguration configuration;
        private string filesConfigurationNode = "PhotographiesFilesPath";

        public PhotosFilesService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<string> GetPhotosList()
        {
            string path = configuration.GetValue<string>(filesConfigurationNode);
            return new DirectoryInfo(path)
                .GetFiles()
                .Select(file => file.Name)
                .ToList();
        }
    }
}
