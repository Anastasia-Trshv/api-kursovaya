using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Abstract
{
    public interface IUserServise
    {
        Task<Guid> CreateUser(User user);
        Task<User> GetUser(string login, string password);
         Task<int> TurnRoleToId(string Role);
         Task<string> TurnIdToRole(int Id);
        Task<bool> CheckUserExist(string email);
    }
}
