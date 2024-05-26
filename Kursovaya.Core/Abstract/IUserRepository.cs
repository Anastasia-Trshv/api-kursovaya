using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Abstract
{
    public interface IUserRepository
    {
         Task<User> Get(string email, string password);
        Task<Guid> Create(User user);
        Task<int> RoleToId(string Role);

       Task<string> IdToRole(int Id);
        Task<bool> CheckUser(string Email);
    }
}
