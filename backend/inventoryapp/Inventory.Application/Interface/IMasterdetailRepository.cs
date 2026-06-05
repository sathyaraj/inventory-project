using Inventory.Application.Servies;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IMasterdetailRepository
    {
        Task AddAsync(Masterdetail masterDetail);

        Task<List<Masterdetail>> GetByMasterIdAsync(int masterId);

    }
}
