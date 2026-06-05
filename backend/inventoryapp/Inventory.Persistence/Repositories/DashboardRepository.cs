using Inventory.Application.Interface;
using Inventory.Infrastructure;
using Inventory.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetDashboardAsync()
        {
            var totalItems = await _context.Items.CountAsync();

            var totalStock = await _context.StoreroomItems
                .Where(x => x.IsDelete != "D")
                .SumAsync(x => (decimal?)x.CurrentBalance) ?? 0;

            var lowStock = await _context.Items
                .Where(x => x.currentStock <= x.MinimumStock)
                .CountAsync();

            return new
            {
                totalItems,
                totalStock,
                lowStock
            };
        }

        public async Task<object> GetOverviewChartAsync(string type)
        {
            var items = await _context.Items.ToListAsync();

            List<string> labels = new();

            List<int> stockData = new();

            // DAY
            if (type == "day")
            {
                var today = DateTime.Today;

                labels.Add("Today");

                stockData.Add(
                    items.Count(x =>
                        x.CreatedDate.HasValue &&
                        x.CreatedDate.Value.Date == today)
                );
            }

            // WEEK
            else if (type == "week")
            {
                var start =
                    DateTime.Today.AddDays(
                        -(int)DateTime.Today.DayOfWeek);

                for (int i = 0; i < 7; i++)
                {
                    var day = start.AddDays(i);

                    labels.Add(day.ToString("ddd"));

                    stockData.Add(
                        items.Count(x =>
                            x.CreatedDate.HasValue &&
                            x.CreatedDate.Value.Date == day.Date)
                    );
                }
            }

            // MONTH
            else
            {
                string[] months =
                {
            "Jan","Feb","Mar","Apr","May","Jun",
            "Jul","Aug","Sep","Oct","Nov","Dec"
        };

                var monthlyData = items
                    .Where(x => x.CreatedDate.HasValue)
                    .GroupBy(x => x.CreatedDate.Value.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Month)
                    .ToList();

                labels = monthlyData
                    .Select(x => months[x.Month - 1])
                    .ToList();

                stockData = monthlyData
                    .Select(x => x.Count)
                    .ToList();
            }

            return new
            {
                labels,
                stockData
            };
        }

        public async Task<object> GetBarChartAsync(string type)
        {
            var items = await _context.Items.ToListAsync();

            List<string> labels = new();

            List<int> totalItemsData = new();

            List<decimal> totalStockData = new();

            // DAY
            if (type == "day")
            {
                var today = DateTime.Today;

                labels.Add("Today");

                var todayItems = items
                    .Where(x =>
                        x.CreatedDate.HasValue &&
                        x.CreatedDate.Value.Date == today)
                    .ToList();

                totalItemsData.Add(todayItems.Count);

                totalStockData.Add(
                    todayItems.Sum(x => x.totalStock ?? 0)
                );
            }

            // WEEK
            else if (type == "week")
            {
                var start =
                    DateTime.Today.AddDays(
                        -(int)DateTime.Today.DayOfWeek);

                for (int i = 0; i < 7; i++)
                {
                    var day = start.AddDays(i);

                    labels.Add(day.ToString("ddd"));

                    var dayItems = items
                        .Where(x =>
                            x.CreatedDate.HasValue &&
                            x.CreatedDate.Value.Date == day.Date)
                        .ToList();

                    totalItemsData.Add(dayItems.Count);

                    totalStockData.Add(
                        dayItems.Sum(x => x.totalStock ?? 0)
                    );
                }
            }

            // MONTH
            else
            {
                string[] months =
                {
            "Jan","Feb","Mar","Apr","May","Jun",
            "Jul","Aug","Sep","Oct","Nov","Dec"
        };

                var monthlyData = items
                    .Where(x => x.CreatedDate.HasValue)
                    .GroupBy(x => x.CreatedDate.Value.Month)
                    .Select(g => new
                    {
                        Month = g.Key,

                        TotalItems = g.Count(),

                        TotalStock =
                            g.Sum(x => x.totalStock ?? 0)
                    })
                    .OrderBy(x => x.Month)
                    .ToList();

                labels = monthlyData
                    .Select(x => months[x.Month - 1])
                    .ToList();

                totalItemsData = monthlyData
                    .Select(x => x.TotalItems)
                    .ToList();

                totalStockData = monthlyData
                    .Select(x => x.TotalStock)
                    .ToList();
            }

            return new
            {
                labels,
                totalItemsData,
                totalStockData
            };
        }

    }
}