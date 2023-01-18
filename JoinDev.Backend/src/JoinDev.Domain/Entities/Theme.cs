using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Core.Validation;
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


        private List<Project> _projects;
        public IReadOnlyCollection<Project> Projects => _projects;

        public Theme(string name, ThemeCategory themeCategory)
        {
            Name = name;
            ThemeCategory = themeCategory;

            Validate();
        }

        protected Theme() { }

        public void Validate()
        {
            Name.ShouldNotBeEmpty(nameof(Name));
        }
    }
}
