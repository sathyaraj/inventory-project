using Inventory.Application.Interface;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockCancelController : ControllerBase
    {
        private readonly IStockCancelRepository _service;

        public StockCancelController(
            IStockCancelRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] StockCancel model)
        {
            var data = await _service.Create(model);

            return Ok(new
            {
                success = true,
                message = "Created successfully",
                data
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] StockCancel model)
        {
            var data = await _service.Update(id, model);

            if (data == null)
                return NotFound();

            return Ok(new
            {
                success = true,
                message = "Updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            if (!result)
                return NotFound();

            return Ok(new
            {
                success = true,
                message = "Deleted successfully"
            });
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _service.Cancel(id);

            if (!result)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Already cancelled"
                });
            }

            return Ok(new
            {
                success = true,
                message = "Cancelled successfully"
            });
        }
    }
}