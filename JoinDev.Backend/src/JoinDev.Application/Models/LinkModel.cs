using JoinDev.Domain.Enums;
using JoinDev.Domain.ValueObjects;

namespace JoinDev.Application.Models
{
    public class LinkModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public LinkSource LinkSource { get; set; }
        public LinkType LinkType { get; set; }

        public static implicit operator LinkModel(Link link)
        {
            return new LinkModel()
            {
                Url = link.Url,
                LinkSource = link.LinkSource,
                LinkType = link.LinkType,
                Name = link.Name
            };
        }
    }
}
