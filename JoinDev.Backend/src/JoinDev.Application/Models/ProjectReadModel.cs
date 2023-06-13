using JoinDev.Application.Mappers;
using JoinDev.Domain.Entities;
using JoinDev.Domain.Enums;

namespace JoinDev.Application.Models
{
    public class ProjectReadModel : ProjectBaseModel
    {
        public string RestrictedDescription { get; set; }
        public List<LinkModel> Links { get; set; }
        public Guid CreatorId { get; set; }

        public static implicit operator ProjectReadModel(Project project)
        {
            var model =  new ProjectReadModel()
            {
                Id = project.Id,             
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
