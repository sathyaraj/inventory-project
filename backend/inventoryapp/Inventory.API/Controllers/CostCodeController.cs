using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostCodeController : ControllerBase
    {
        private readonly CostCodeService _service;

        public CostCodeController(CostCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CostCode costCode)
        {
            await _service.AddAsync(costCode);

            return Ok(new
            {
                success = true,
                message = "Cost Code Created Successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CostCode costCode)
        {
            costCode.Id = id;

            await _service.UpdateAsync(costCode);

            return Ok(new
            {
                success = true,
                message = "Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok(new
            {
                success = true,
                message = "Deleted Successfully"
            });
        }
    }
}
