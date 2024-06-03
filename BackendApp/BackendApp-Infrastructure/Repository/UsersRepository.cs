using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BackendApp_Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {

        readonly DataBaseContext _context;

        public UsersRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<UserDTO?> Get(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<UserDTO?> Get(string email, string password)
        {
            return await (from user in _context.Users
                          where user.Email.ToLower() == email.ToLower() && user.Password == password
                          select new UserDTO
                          {
                              Email = user.Email,
                              Id = user.Id,
                              Name = user.Name
                          }).FirstOrDefaultAsync();
        }
    }
}
