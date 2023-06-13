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

        public static implicit operator UserModel(User user)
        {
            return new UserModel()
            {
                Description = user.Description,
                Image = user.Image,
                Email = user.Email,
                Name = user.Name,
                Links = user.Links?.ToLinkModels().ToList(),
            };
        }
    }
}
