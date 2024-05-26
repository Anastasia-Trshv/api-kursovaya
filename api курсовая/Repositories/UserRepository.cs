using api_курсовая.model;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace api_курсовая.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Get( string email, string password)
        {
           

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password==password);
            if (user != null)
            {
                var userRole = IdToRole(user.Role);
                var user1 = User.Create(user.Id, user.Name, user.Email, user.Password, userRole.ToString());
                return user1;
            }
            else
            {
                var us = new User();
                return us;
            }
         
        }

        public async Task<Guid> Create(User user)
        {
            var userRole = _context.Roles.FirstOrDefault(r => user.Role == r.Role_name);
            UserEntity newuser = new UserEntity( user.Name, user.Email, user.Password, userRole.Id);
            await _context.Users.AddAsync(newuser);
            await _context.SaveChangesAsync();
            return newuser.Id;
        }
        public async Task<int> RoleToId(string Role)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(r => Role == r.Role_name);
            return (userRole.Id);
        }

        public async Task<string> IdToRole(int Id)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(r => Id == r.Id);
            return (userRole.Role_name);
        }

        public async Task<bool> CheckUser(string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(r => r.Email == Email);
            if(user == null)
            {
                return false;
            }
            else { return true; }
        }
    }
}
