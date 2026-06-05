using Inventory.Application.Interface;
using Inventory.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _repo;

        public DashboardController(IDashboardRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var result = await _repo.GetDashboardAsync();

            return Ok(result);
        }

        [HttpGet("overview-chart")]
        public async Task<IActionResult> GetOverviewChart(string type = "month")
        {
            var result =
                await _repo.GetOverviewChartAsync(type);

            return Ok(result);
        }

        [HttpGet("bar-chart")]
        public async Task<IActionResult> GetBarChart(
    string type = "month")
        {
            var result =
                await _repo.GetBarChartAsync(type);

            return Ok(result);
        }


    }
}
