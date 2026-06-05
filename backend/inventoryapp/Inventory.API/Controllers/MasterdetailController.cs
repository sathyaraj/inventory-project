using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Inventory.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class MasterdetailController : ControllerBase
    {
        private readonly IMasterdetailRepository _mastedetailrepository;

        public MasterdetailController(IMasterdetailRepository mastedetailrepository)
        {
            _mastedetailrepository = mastedetailrepository;
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] Masterdetail masterdetail)
        {
                    await _mastedetailrepository.AddAsync(masterdetail);
                    return Ok(masterdetail);
        }

        [HttpGet("{masterId}")]
        public async Task<IActionResult> GetByMasterId(int masterId)
        {
            try
            {
                var data = await _mastedetailrepository.GetByMasterIdAsync(masterId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }

    }
}
