using JoinDev.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JoinDevContext _context;

        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;

        public UnitOfWork(JoinDevContext context, IUserRepository userRepository, IProjectRepository projectRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        public IUserRepository Users => _userRepository;
        public IProjectRepository Projects => _projectRepository;

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
