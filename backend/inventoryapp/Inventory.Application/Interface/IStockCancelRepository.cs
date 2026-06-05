using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IStockCancelRepository
    {
        Task<List<StockCancel>> GetAll();

        Task<StockCancel?> GetById(int id);

        Task<StockCancel> Create(StockCancel model);

        Task<StockCancel?> Update(int id, StockCancel model);

        Task<bool> Delete(int id);

        Task<bool> Cancel(int id);
    }
}
