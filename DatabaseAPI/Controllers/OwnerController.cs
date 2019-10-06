using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.Common.Routing;
using DatabaseAPI.Inner.Logic.Owner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OwnerDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetAllOwnersAsync()
        {
            IEnumerable<OwnerDTO> items = await service.GetAllOwnersAsync();
            FillWithUrls(items);
            return Ok(items);
        }

        private void FillWithUrls(IEnumerable<OwnerDTO> items)
        {
            foreach (OwnerDTO dto in items)
            {
                dto.Url = UriRoute.GetRouteStringFromNodes(
                    OWNER_PATH,
                    dto.Id.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(OwnerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostOwnerAsync(OwnerDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }
                OwnerDTO result = await service.PostOwnerAsync(model);
                return Ok(result);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //todo [FromUri] int id
        public async Task<IActionResult> DeleteOwnerAsync(int id)
        {
            try
            {
                bool successfullyDeleted = await service.DeleteOwnerByIdAsync(id);
                if (successfullyDeleted)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }
    }
}
