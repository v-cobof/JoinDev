using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data.DAO
{
    public class ThemeCategoryDAO : IThemeCategoryDAO
    {
        private readonly JoinDevContext _context;

        public ThemeCategoryDAO(JoinDevContext context)
        {
            _context = context;
        }

        public async Task<ThemeCategory> GetThemeCategoryById(Guid id)
        {
            return await _context.ThemeCategories.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ThemeCategory> GetThemeCategoryByName(string name)
        {
            return await _context.ThemeCategories.FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<bool> CreateThemeCategory(ThemeCategory category)
        {
            _context.ThemeCategories.Add(category);

            return await _context.Commit();
        }
    }
}
