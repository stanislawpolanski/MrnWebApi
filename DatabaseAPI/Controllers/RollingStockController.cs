using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using DatabaseAPI.Inner.Logic.RollingStockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RollingStockDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RollingStockDTO>>> GetAllRollingStockAsync()
        {
            IEnumerable<RollingStockDTO> items = await service.GetAllRollingStockAsync();
            FillWithUrls(items);
            return Ok(items);
        }

        private void FillWithUrls(IEnumerable<RollingStockDTO> items)
        {
            foreach (RollingStockDTO dto in items)
            {
                dto.Url = UriRoute.GetRouteStringFromNodes(
                    ROLLING_STOCK_PATH,
                    dto.Id.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RollingStockDTO>> PostRollingStockAsync(
            RollingStockDTO inputDto)
        {
            RollingStockDTO resultDto = await service.PostRollingStockAsync(inputDto);
            if (resultDto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostRollingStockAsync), resultDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await service.DeleteRollingStockByIdAsync(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAsync(
            int id,
            [FromBody] RollingStockDTO dto)
        {
            if (dto.Id != id)
            {
                return BadRequest();
            }
            bool putSuccessfully = await service.PutRollingStockAsync(dto);
            if (putSuccessfully)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}