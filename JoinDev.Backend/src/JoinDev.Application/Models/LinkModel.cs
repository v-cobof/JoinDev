using JoinDev.Domain.Enums;
using JoinDev.Domain.ValueObjects;

namespace JoinDev.Application.Models
{
    public class LinkModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid LinkSourceId { get; set; }

        public static implicit operator LinkModel(Link link)
        {
            return new LinkModel()
            {
                Url = link.Url,
                LinkSourceId = link.LinkSourceId,
                Name = link.Name
            };
        }

        public LinkModel() { }
    }
}
