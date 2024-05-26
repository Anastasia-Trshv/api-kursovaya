using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Application.Services
{
    public class UserServise : IUserServise
    {
        private readonly IUserRepository _userRepository;
        public UserServise(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<Guid> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<User> GetUser(string login, string password)
        {
            return await _userRepository.Get(login, password);
        }

        public async Task<int> TurnRoleToId(string Role)
        {
            
            return (await _userRepository.RoleToId(Role));
        }

        public async Task<string> TurnIdToRole(int Id)
        {
            return (await _userRepository.IdToRole(Id));
        }
        public async Task<bool> CheckUserExist(string email)
        {
            return (await _userRepository.CheckUser(email));
        }
    }
}
