using Inventory.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class DashboardService : IDashboardRepository
    {
        private readonly IDashboardRepository _repo;

        public DashboardService(IDashboardRepository repo)
        {
            _repo = repo;
        }

        public async Task<object> GetDashboardAsync()
        {
            return await _repo.GetDashboardAsync();
        }

        //public async Task<object> GetOverviewChartAsync()
        //{
        //    return await _repo.GetOverviewChartAsync();
        //}

        public async Task<object> GetOverviewChartAsync(string type)
        {
            return await _repo.GetOverviewChartAsync(type);
        }

        public async Task<object> GetBarChartAsync(string type)
        {
            return await _repo.GetBarChartAsync(type);
        }
    }
}
