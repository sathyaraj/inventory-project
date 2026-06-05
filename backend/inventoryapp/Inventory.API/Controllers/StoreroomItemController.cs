using Inventory.Application.Servies;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreroomController : ControllerBase
    {
        private readonly StoreroomService _service;

        public StoreroomController(StoreroomService service)
        {
            _service = service;
        }

        // 🔍 GET LIST
        [HttpGet("{itemId}")]
        public async Task<IActionResult> Get(int itemId)
        {
            var data = await _service.GetByItemId(itemId);
            return Ok(data);
        }

        // ➕ CREATE
        [HttpPost("{itemId}")]
        public async Task<IActionResult> Create(int itemId, [FromBody] List<StoreroomItem> items)
        {
            try
            {
                if (items == null || !items.Any())
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "No data provided"
                    });
                }

                await _service.SaveItems(itemId, items);

                return Ok(new
                {
                    success = true,
                    message = "Storeroom items saved successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error",
                    error = ex.Message // optional (remove in production)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreroomItem item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "No data provided"
                    });
                }

                await _service.AddItemAsync(item);

                return Ok(new
                {
                    success = true,
                    message = "Storeroom item saved successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        //// ✏️ UPDATE
        //[HttpPut("{itemId}")]
        //public async Task<IActionResult> Update(int itemId, [FromBody] List<StoreroomItem> items)
        //{
        //    if (items == null || !items.Any())
        //        return BadRequest("No data");

        //    await _service.UpdateItems(itemId, items);
        //    return Ok("Updated");
        //}

        [HttpPut("update-status/{itemId}")]
        public async Task<IActionResult> UpdateStatus(int itemId, [FromBody] bool status)
        {
            try
            {
                await _service.UpdateStatusAsync(itemId, status);
                return Ok(new
                {
                    success = true,
                    message = "Status updated successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllItems();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _service.DeleteItem(id);

                if (!result)
                    return NotFound(new { message = "Item not foundsss" });

                return Ok(new { message = "Item deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error while deleting item",
                    error = ex.Message   // remove in production if needed
                });
            }
        }
    }
}
