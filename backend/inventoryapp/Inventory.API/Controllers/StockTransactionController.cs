using Inventory.Application.Interface;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionController: ControllerBase
    {
        private readonly IStockTransactionRepository _service;

        public StockTransactionController(
            IStockTransactionRepository service)
        {
            _service = service;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(
            StockTransaction model)
        {
            var result = await _service
                .CreateAsync(model);

            return Ok(result);
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service
                .GetAllAsync();

            return Ok(result);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service
                .GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET BY ITEM ID
        [HttpGet("item/{itemId}")]
        public async Task<IActionResult>
            GetByItemId(int itemId)
        {
            var result = await _service
                .GetByItemIdAsync(itemId);

            return Ok(result);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            StockTransaction model)
        {
            if (id != model.StockTnsId)
            {
                return BadRequest();
            }

            var result = await _service
                .UpdateAsync(model);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Updated Successfully"
            });
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service
                .DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Deleted Successfully"
            });
        }
    }
}