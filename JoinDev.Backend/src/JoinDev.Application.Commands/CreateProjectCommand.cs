using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Enums;

namespace JoinDev.Application.Commands
{
    public abstract class CreateProjectCommand : Command
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public Guid CreatorId { get; set; }
        public List<Guid> ThemesIds { get; set; }
    }

    public class CreateJobProjectCommand : CreateProjectCommand
    { 
        public JobProjectLevel JobProjectLevel { get; set; }
        public decimal MemberPayment { get; set; }
    }

    public class CreateStudyProjectCommand : CreateProjectCommand
    {
        public StudyProjectLevel StudyProjectLevel { get; set; }
    }
}
