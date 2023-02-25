using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data.DAO
{
    public class ThemeDAO : IThemeDAO
    {
        private readonly JoinDevContext _context;

        public ThemeDAO(JoinDevContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTheme(Theme theme)
        {
            _context.Themes.Add(theme);

            return await _context.Commit();
        }

        public void UpdateTheme(Theme theme)
        {
            throw new NotImplementedException();
        }

        public async Task<Theme> GetThemeByName(string name)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}
