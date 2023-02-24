using JoinDev.Domain.Core.Data;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Data
{
    public interface ICategoryRepository
    {
        Task<ThemeCategory> GetThemeCategoryById(Guid id);
        Task<ThemeCategory> GetThemeCategoryByName(string name);
        void CreateThemeCategory(ThemeCategory category);

        Task<LinkSource> GetThemeCategoryById(Guid id);
        Task<ThemeCategory> GetThemeCategoryByName(string name);
        void CreateThemeCategory(ThemeCategory category);
    }
}
