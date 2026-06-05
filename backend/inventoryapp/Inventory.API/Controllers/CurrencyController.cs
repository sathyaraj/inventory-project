using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _service;

        public CurrencyController(CurrencyService service)
        {
            _service = service;
        }

        // GET: api/currency
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/currency/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST: api/currency
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CurrencyDetails currency)
        {
            await _service.AddAsync(currency);

            return Ok(new
            {
                message = "Currency Created Successfully"
            });
        }

        // PUT: api/currency
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] CurrencyDetails currency)
        {
            currency.Id = id;

            await _service.UpdateAsync(currency);

            return Ok(new
            {
                message = "Currency Updated Successfully"
            });
        }

        // DELETE: api/currency/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok(new
            {
                message = "Currency Deleted Successfully"
            });
        }
    }
}