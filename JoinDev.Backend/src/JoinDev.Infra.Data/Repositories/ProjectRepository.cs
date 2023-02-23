using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Domain.Enums;
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

        public void Create(Project project)
        {
            _context.Projects.Add(project);
        }

        public async Task<Project> GetById(Guid id)
        {
            var proj = await _context.Projects.FindAsync(id);

            return proj;
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects
                .Include(t => t.ProjectRestrictedInfo)
                .Include(t => t.Creator)
                .Include(t => t.MemberUsers)
                .Include(t => t.InterestedUsers)
                .ToListAsync();  
        }

        public void CreateTheme(Theme theme)
        {
            _context.Themes.Add(theme);
        }

        public void UpdateTheme(Theme theme)
        {
            throw new NotImplementedException();
        }

        public async Task<Theme> GetThemeByName(string name)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Name == name);
        }

        public Task<ThemeCategory> GetThemeCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<ThemeCategory> GetThemeCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateThemeCategory(ThemeCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
