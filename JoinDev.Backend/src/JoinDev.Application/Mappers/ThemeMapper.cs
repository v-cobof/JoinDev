using JoinDev.Application.Models;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Mappers
{
    public static class ThemeMapper
    {
        public static IEnumerable<ThemeModel> ToThemeModels(this IEnumerable<Theme> themes)
        {
            foreach (var theme in themes)
            {
                yield return theme;
            }
        }
    }
}
