using JoinDev.Domain.Enums;
using JoinDev.Domain.ValueObjects;

namespace JoinDev.Application.Models
{
    public class LinkModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid LinkSourceId { get; set; }
        public LinkType? Type { get; private set; }

        public static implicit operator LinkModel(Link link)
        {
            return new LinkModel()
            {
                Url = link.Url,
                LinkSourceId = link.LinkSourceId,
                Type = link.LinkType,
                Name = link.Name
            };
        }

        public void SetAsUserLink()
        {
            Type = LinkType.UserLink;
        }

        public void SetAsProjectLink()
        {
            Type = LinkType.ProjectLink;
        }
    }
}
