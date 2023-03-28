using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Enums;

namespace JoinDev.Application.Commands
{
    public class CreateProjectCommand : Command
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public Guid CreatorId { get; set; }
        public string RestrictedDescription { get; set; }
        public List<Guid> ThemesIds { get; set; }
        public List<LinkModel> Links { get; set; }


        public ProjectType ProjectType { get; set; }
        public StudyProjectLevel StudyProjectLevel { get; set; }
        public JobProjectLevel JobProjectLevel { get; set; }
        public decimal MemberPayment { get; set; }
    }
}
