
using Inventory.Application.Services;
using Inventory.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController
        : ControllerBase
    {
        private readonly TaxService
            _service;

        public TaxController(
            TaxService service)
        {
            _service = service;
        }

        // COMMON ERROR FUNCTION
        private IActionResult
            HandleException(Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = ex.Message
            });
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult>
            GetAll()
        {
            try
            {
                var data =
                    await _service
                        .GetAllAsync();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(int id)
        {
            try
            {
                var data =
                    await _service
                        .GetByIdAsync(id);

                if (data == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message =
                        "Tax not found"
                    });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // SAVE
        [HttpPost]
        public async Task<IActionResult>
            Save(Tax model)
        {
            try
            {
                await _service
                    .SaveAsync(model);

                return Ok(new
                {
                    success = true,

                    message =
                    model.Id > 0
                    ? "Updated Successfully"
                    : "Saved Successfully"
                });
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(int id)
        {
            try
            {
                await _service
                    .DeleteAsync(id);

                return Ok(new
                {
                    success = true,
                    message =
                    "Deleted Successfully"
                });
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}