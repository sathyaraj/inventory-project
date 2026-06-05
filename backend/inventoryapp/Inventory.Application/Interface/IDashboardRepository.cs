using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IDashboardRepository
    {
        Task<object> GetDashboardAsync();

        //Task<object> GetOverviewChartAsync();

        Task<object> GetOverviewChartAsync(string type);

        Task<object> GetBarChartAsync(string type);
    }
}
