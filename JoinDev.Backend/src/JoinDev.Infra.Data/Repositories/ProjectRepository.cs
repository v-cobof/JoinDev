using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Infra.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly JoinDevContext _context;

        public ProjectRepository(JoinDevContext context)
        {
            _context = context;
        }

        public void CreateProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Project> GetById(Guid id)
        {
            var proj = await _context.Projects.FindAsync(id);

            return proj;
        }
    }
}
