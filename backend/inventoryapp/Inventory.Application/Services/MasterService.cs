using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Servies
{
    public class MasterService
    {
         private readonly IMasterRepository _orpe;

        public MasterService(IMasterRepository orpe)
        {
            _orpe = orpe;
        }

        public async Task AddAsync(Master master)
        {
            await _orpe.AddAsync(master);
        }
    }
}
