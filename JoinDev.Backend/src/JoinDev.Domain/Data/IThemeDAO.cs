using JoinDev.Domain.Entities;

namespace JoinDev.Domain.Data
{
    public interface IThemeDAO
    {
        Task<bool> CreateTheme(Theme theme);
        void UpdateTheme(Theme theme);
        Task<Theme> GetThemeByName(string name);
    }
}
