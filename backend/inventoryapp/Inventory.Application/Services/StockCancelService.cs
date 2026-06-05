using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Inventory.Application.Services.StockCancelService;

namespace Inventory.Application.Services
{
    public class StockCancelService
    {
        
            private readonly IStockCancelRepository _repository;

            public StockCancelService(
                IStockCancelRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<StockCancel>> GetAll()
            {
                return await _repository.GetAll();
            }

            public async Task<StockCancel?> GetById(int id)
            {
                return await _repository.GetById(id);
            }

            public async Task<StockCancel> Create(StockCancel model)
            {
                return await _repository.Create(model);
            }

            public async Task<StockCancel?> Update(int id, StockCancel model)
            {
                return await _repository.Update(id, model);
            }

            public async Task<bool> Delete(int id)
            {
                return await _repository.Delete(id);
            }

            public async Task<bool> Cancel(int id)
            {
                return await _repository.Cancel(id);
            }
        }
    }

