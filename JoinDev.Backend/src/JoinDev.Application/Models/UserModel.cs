using JoinDev.Application.Mappers;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }

        public List<LinkModel> Links { get; set; }

        public List<Guid> ProjectsAsCreator { get; set; }
        public List<Guid> ProjectsAsMember { get; set; }
        public List<Guid> ProjectsAsInterested { get; set; }

        public static implicit operator UserModel(User user)
        {
            return new UserModel()
            {
                Description = user.Description,
                Image = user.Image,
                Email = user.Email,
                Name = user.Name,
                Links = user.Links?.ToLinkModels().ToList(),
                ProjectsAsCreator = user.ProjectsAsCreator?.Select(t => t.Id).ToList(),
                ProjectsAsMember = user.ProjectsAsMember?.Select(t => t.Id).ToList(),
                ProjectsAsInterested = user.ProjectsAsInterested?.Select(t => t.Id).ToList(),
            };
        }
    }
}
