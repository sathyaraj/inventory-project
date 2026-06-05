using Inventory.Application.Servies;
using Inventory.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Inventory.Domain.Entities;

namespace Inventory.API.Controllers
{
    public class ItemConditionController : ControllerBase
    {
        private readonly ItemConditionService _service;
        public ItemConditionController(ItemConditionService service)
        {
            _service = service;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> Get(int itemId)
        {
            var data = await _service.GetByItemId(itemId);
            return Ok(data);
        }

        [HttpPost("{itemId}")]
        public async Task<IActionResult> Create(int itemId, [FromBody] List<ItemCondition> conditions)
        {
            if (conditions == null || !conditions.Any())
                return BadRequest("No data");

            await _service.AddItemCondition(itemId, conditions);
            return Ok("Saved");
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> Delete(int itemId)
        {
            await _service.DeleteByItemId(itemId);
            return Ok("Deleted");
        }

    }
}
