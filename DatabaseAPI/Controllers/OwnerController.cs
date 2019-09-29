using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Logic.Owner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace DatabaseAPI.Controllers
{
    [ApiController]
    [Route(OWNER_PATH)]
    public class OwnerController : DatabaseApiController
    {
        public const string OWNER_PATH = DATABASE_ROOT_API_PATH + "/owner";
        private IOwnerLogicService service;

        public OwnerController(IOwnerLogicService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OwnerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OwnerDTO>> GetRollingStockByIdAsync(int id)
        {
            OwnerDTO item = await service.GetOwnerByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
