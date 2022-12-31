using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Entities
{
    public class Theme : Entity
    {
        public string Name { get; private set; }

        public ThemeCategory ThemeCategory { get; private set; }

        public Theme(string name, ThemeCategory themeCategory)
        {
            Name = name;
            ThemeCategory = themeCategory;
        }
    }
}
