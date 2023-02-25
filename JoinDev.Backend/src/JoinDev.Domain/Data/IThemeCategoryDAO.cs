using JoinDev.Domain.Entities;

namespace JoinDev.Domain.Data
{
    public interface IThemeCategoryDAO
    {
        Task<ThemeCategory> GetThemeCategoryById(Guid id);
        Task<ThemeCategory> GetThemeCategoryByName(string name);
        Task<bool> CreateThemeCategory(ThemeCategory category);
    }
}
