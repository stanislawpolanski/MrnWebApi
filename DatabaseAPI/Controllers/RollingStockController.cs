using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Logic.RollingStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatabaseAPI.Controllers
{
    [Route(ROLLING_STOCK_PATH)]
    [ApiController]
    public class RollingStockController : DatabaseApiController
    {
        public const string ROLLING_STOCK_PATH = DATABASE_ROOT_API_PATH + "/rolling-stock";

        private IRollingStockLogicService service;

        public RollingStockController(IRollingStockLogicService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RollingStockDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RollingStockDTO>> GetRollingStockByIdAsync(int id)
        {
            RollingStockDTO item = await service.GetRollingStockByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}