using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocklistController : ControllerBase
    {
        private readonly IStockListRepository _repo;

        public StocklistController(IStockListRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Stocklist stock)
        {
            await _repo.AddAsync(stock);
            return Ok(new { message = "Stock added successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Stocklist stock)
        {
            await _repo.UpdateAsync(stock);
            return Ok(new { message = "Stock updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok(new { message = "Stock deleted successfully" });
        }
    }
}