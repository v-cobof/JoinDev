using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Core.Validation;
using JoinDev.Domain.ValueObjects;

namespace JoinDev.Domain.Entities
{
    public class LinkSource : Entity
    {
        public string Name { get; private set; }


        private List<Link> _links;
        public IReadOnlyCollection<Link> Links => _links;

        public LinkSource(string name)
        {
            Name = name;

            Validate();
        }

        protected LinkSource() { }

        public void Validate()
        {
            Name.ShouldNotBeEmpty(nameof(Name));
        }
    }
}
