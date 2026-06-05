using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceItemController : ControllerBase
    {
        private readonly ServiceItemService _service;

        public ServiceItemController(
            ServiceItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ServiceItem item)
        {
            var result =
                await _service.CreateAsync(item);

            return Ok(new
            {
                message = "Created Successfully",
                data = result
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =
                await _service.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            int id)
        {
            var item =
                await _service.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ServiceItem item)
        {
            var result =
                await _service.UpdateAsync(id, item);

            if (result == null)
                return NotFound();

            return Ok(new
            {
                message = "Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            var result =
                await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Deleted Successfully"
            });
        }

        [HttpGet("lastid")]
        public async Task<IActionResult> GetLastId()
        {
            var id = await _service.GetLastInsertedIdAsync();

            return Ok(new
            {
                success = true,
                lastId = id
            });
        }
    }
}