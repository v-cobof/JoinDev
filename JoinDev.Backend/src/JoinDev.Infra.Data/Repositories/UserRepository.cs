using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JoinDevContext _context;

        public UserRepository(JoinDevContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
