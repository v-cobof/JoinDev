using JoinDev.Domain.Core.Validation;
using JoinDev.Domain.Entities;
using JoinDev.Domain.Enums;

namespace JoinDev.Domain.ValueObjects
{
    public class Link
    {
        public Guid AggregateId { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public Guid LinkSourceId { get; private set; }
        public LinkSource LinkSource { get; private set; }
        public LinkType LinkType { get; private set; }

        public Link(Guid aggregateId, string name, string url, LinkSource linkSource, LinkType linkType)
        {
            AggregateId = aggregateId;
            Name = name;
            Url = url;
            LinkSource = linkSource;
            LinkType = linkType;
        }

        protected Link() { }

        protected virtual void Validate()
        {
            Name.ShouldNotBeEmpty(nameof(Name));
            Url.ShouldNotBeEmpty(nameof(Url));
        }

        public override bool Equals(object obj)
        {
            var compare = obj as Link;

            return Url.Equals(compare.Url);
        }

        public static bool operator ==(Link a, Link b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Link a, Link b)
        {
            return !(a == b);
        }
    }
}
