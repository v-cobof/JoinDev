using JoinDev.Application.Mappers;
using JoinDev.Application.Models;
using JoinDev.Domain.Entities;
using JoinDev.Domain.Enums;

namespace JoinDev.Application.Queries.ViewModels
{
    public class ProjectDisplayViewModel  : ProjectBaseModel
    {
        public static implicit operator ProjectDisplayViewModel(ProjectReadModel project)
        {
            return new ProjectDisplayViewModel()
            {
                Id = project.Id,
                Title = project.Title,
                PublicDescription = project.PublicDescription,
                TotalSpots = project.TotalSpots,
                ProjectStatus = project.ProjectStatus,
                AvailableSpots = project.AvailableSpots,
                Themes = project.Themes,
                ProjectType = project.ProjectType,
                JobProjectLevel = project.JobProjectLevel,
                MemberPayment = project.MemberPayment,
                StudyProjectLevel = project.StudyProjectLevel
            };
        }
    }
}
