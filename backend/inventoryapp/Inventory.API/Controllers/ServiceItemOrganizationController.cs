using Inventory.Application.Interface;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Inventory.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceItemOrganizationController : ControllerBase
    {
        private readonly IServiceItemOrganizationRepository _repo;

        public ServiceItemOrganizationController(IServiceItemOrganizationRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceItemOrganization item)
        {
            var result = await _repo.AddAsync(item);
            return Ok(new
            {
                message = "Service Item Created Successfully",
                data = result
            });
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return Ok(data);
        }
    }
}
