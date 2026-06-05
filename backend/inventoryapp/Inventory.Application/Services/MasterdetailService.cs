using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Servies
{
    public class MasterdetailService
    {
        private readonly IMasterdetailRepository _orpe;

        public MasterdetailService(IMasterdetailRepository orpe)
        {
            _orpe = orpe;
        }

        public async Task AddAsync(Masterdetail masterdetail)
        {
            await _orpe.AddAsync(masterdetail);
        }
    }
}
