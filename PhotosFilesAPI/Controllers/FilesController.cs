using Microsoft.AspNetCore.Mvc;
using PhotosFilesAPI.Services;
using System.Collections.Generic;

namespace PhotosFilesAPI.Controllers
{
    [Route("photos-api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IPhotosService service;

        public FilesController(IPhotosService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFileNames()
        {
            return Ok(service.GetPhotosList());
        }
    }
}
