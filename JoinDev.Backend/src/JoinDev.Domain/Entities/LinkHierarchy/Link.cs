using JoinDev.Domain.Core.DomainObjects;
using JoinDev.Domain.Enums;

namespace JoinDev.Domain.Entities
{
    public abstract class Link : Entity
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public LinkSource LinkSource { get; private set; }

        public Link(string name, string url, LinkSource linkSource)
        {
            Name = name;
            Url = url;
            LinkSource = linkSource;
        }

        protected Link() { }
    }
}
