using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Core.Validation;

namespace JoinDev.Domain.Entities
{
    public class ThemeCategory : Entity
    {
        public string Name { get; private set; }


        private List<Theme> _themes;
        public IReadOnlyCollection<Theme> Themes => _themes;

        public ThemeCategory(string name)
        {
            Name = name;

            Validate();
        }

        protected ThemeCategory() { }

        public void Validate()
        {
            Name.ShouldNotBeEmpty(nameof(Name));
        }
    }
}
