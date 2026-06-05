using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IMasterRepository _masterRepository;

        public MasterController(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Master master)
        {
            await _masterRepository.AddAsync(master);
            return Ok(master);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _masterRepository.GetAllAsync();
            return Ok(data);
        }
    }
}
