using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Models
{
    public class ThemeModel : BaseModel
    {
        public string Name { get; set; }
        public string ThemeCategoryName { get; set; }
        public Guid ThemeCategoryId { get; set; }

        public static implicit operator ThemeModel(Theme project)
        {
            return new ThemeModel()
            {
                Name = project.Name,
                ThemeCategoryName = project.ThemeCategory.Name,
                ThemeCategoryId = project.ThemeCategoryId
            };
        }
    }
}
