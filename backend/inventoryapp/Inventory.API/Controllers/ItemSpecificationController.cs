using Inventory.Application.Interface;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemSpecificationController : ControllerBase
    {
        private readonly IItemSpecificationRepository _repo;

        public ItemSpecificationController(IItemSpecificationRepository repo)
        {
            _repo = repo;
        }

  

        // ✅ CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemSpecification model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Invalid input",
                        data = (object)null
                    });
                }

                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(model));

                var result = await _repo.CreateAsync(model);

                return Ok(new
                {
                    success = true,
                    message = "Created successfully",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    data = (object)null
                });
            }
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _repo.GetAllAsync();

                return Ok(new
                {
                    success = true,
                    message = "Data fetched successfully",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    data = (object)null
                });
            }
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _repo.GetByIdAsync(id);

                if (data == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = $"ItemSpecification with id {id} not found",
                        data = (object)null
                    });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    data = (object)null
                });
            }
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);

                return Ok(new
                {
                    success = true,
                    message = "Deleted successfully",
                    data = (object)null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    data = (object)null
                });
            }
        }
    }
}
