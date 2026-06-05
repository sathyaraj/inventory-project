using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlternatesController : ControllerBase
    {
        private readonly AlternatesService _service;

        public AlternatesController(AlternatesService service)
        {
            _service = service;
        }

        // 🔍 Get
        [HttpGet("{itemId}")]
        public async Task<IActionResult> Get(int itemId)
        {
            var data = await _service.GetByItemId(itemId);
            return Ok(data);
        }

        // ➕ Create
        [HttpPost]
        public async Task<IActionResult> Create(int itemId, [FromBody] List<AlternatesItem> alternates)
        {
            await _service.SaveAlternates(itemId, alternates);
            return Ok("Saved");
        }

        // ❌ Delete
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> Delete(int itemId)
        {
            await _service.DeleteByItemId(itemId);
            return Ok("Deleted");
        }
    }
}
