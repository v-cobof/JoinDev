using JoinDev.Application.Mappers;
using JoinDev.Domain.Entities;
using JoinDev.Domain.Enums;

namespace JoinDev.Application.Models
{
    public class ProjectModel : BaseModel
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public Guid CreatorId { get; set; }
        public int AvailableSpots { get; set; }
        public ProjectType ProjectType { get; set; }
        private List<ThemeModel> Themes { get; set; }
        public string RestrictedDescription { get; set; }
        public List<LinkModel> Links { get; set; }

        public StudyProjectLevel? StudyProjectLevel { get; set; }
        public JobProjectLevel? JobProjectLevel { get; set; }
        public decimal? MemberPayment { get; set; }

        public static implicit operator ProjectModel(Project project)
        {
            var model =  new ProjectModel()
            {
                Title = project.Title,
                PublicDescription = project.PublicDescription,
                TotalSpots = project.TotalSpots,
                ProjectStatus = project.ProjectStatus,
                CreatorId = project.CreatorId,
                AvailableSpots = project.AvailableSpots,
                Themes = project.Themes.ToThemeModels().ToList(),
                RestrictedDescription = project.ProjectRestrictedInfo.Description,
                Links = project.ProjectRestrictedInfo.Links.ToLinkModels().ToList(),
            };

            model.HandleProjectTypeMapping(project);

            return model;
        }
    }
}
