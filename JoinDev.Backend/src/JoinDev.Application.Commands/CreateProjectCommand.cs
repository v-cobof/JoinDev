using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;

namespace JoinDev.Application.Commands
{
    public class CreateProjectCommand : Command
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public Guid CreatorId { get; set; }

        public string PrivateDescription { get; set; }
        public List<ThemeModel> Themes { get; set; }
        public List<LinkModel> Links { get; set; }
    }
}
