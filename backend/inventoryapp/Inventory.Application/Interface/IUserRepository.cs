using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);

        Task<User> CreateAsync(User user);
    }
}
