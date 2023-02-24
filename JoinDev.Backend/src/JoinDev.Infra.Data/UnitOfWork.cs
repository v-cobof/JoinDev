using JoinDev.Domain.Core.Communication;
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
        private readonly IBusHandler _bus;

        public UnitOfWork(JoinDevContext context, IUserRepository userRepository, IProjectRepository projectRepository, IBusHandler bus)
        {
            _context = context;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _bus = bus;
        }

        public IUserRepository Users => _userRepository;
        public IProjectRepository Projects => _projectRepository;

        public async Task<bool> Commit()
        {
            var sucesso = await _context.SaveChangesAsync() > 0;

            if (sucesso) await _bus.PublishEntityEvents(_context);

            return sucesso;
        },
    }
}
