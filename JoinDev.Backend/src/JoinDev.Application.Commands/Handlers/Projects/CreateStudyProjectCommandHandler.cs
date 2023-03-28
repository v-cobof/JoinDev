using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers.Projects
{
    public class CreateStudyProjectCommandHandler : CreateProjectCommandHandler<CreateStudyProjectCommand>
    {
        public CreateStudyProjectCommandHandler(IBusHandler bus,
                                                IProjectRepository projectRepository,
                                                IUserRepository userRepository) : base(bus, projectRepository, userRepository)
        {
        }

        protected override Project CreateProject(CreateStudyProjectCommand request, List<Theme> themes)
        {
            return new StudyProject(request.Title, request.PublicDescription, request.TotalSpots, themes, request.CreatorId, request.StudyProjectLevel);
        }
    }
}
