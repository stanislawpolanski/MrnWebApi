using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PhotosFilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFileNames()
        {
            return new string[] { "value1.jpg", "value2.jpg" };
        }
    }
}
