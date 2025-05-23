using GRE.Application.Interfaces.Services.Store;
using GRE.Shared.DTOs.Store;
using GRE.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTerritory([FromBody] TerritoryDto territoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.AddTerritoryAsync(territoryDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddStore([FromBody] StoreDto storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.AddStoreAsync(storeDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTerritory([FromBody] TerritoryDto territoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.UpdateTerritoryAsync(territoryDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTerritory([FromBody] int territoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.DeleteTerritoryAsync(territoryId));
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStore([FromBody] StoreDto storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.UpdateStoreAsync(storeDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteStore([FromBody] int storeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _storeService.DeleteStoreAsync(storeID));
        }
    }
}
