using Inventory.Application.Services;
using Inventory.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController
        : ControllerBase
    {
        private readonly DiscountService
            _service;

        public DiscountController(
            DiscountService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult>
            GetAll()
        {
            return Ok(
                await _service.GetAllAsync()
            );
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(int id)
        {
            return Ok(
                await _service.GetByIdAsync(id)
            );
        }

        // SAVE
        [HttpPost]
        public async Task<IActionResult>
            Save(Discount model)
        {
            await _service.SaveAsync(model);

            return Ok(new
            {
                message =
                "Saved Successfully"
            });
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok(new
            {
                message =
                "Deleted Successfully"
            });
        }
    }
}