using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers.Projects
{
    public class CreateJobProjectCommandHandler : CreateProjectCommandHandler<CreateJobProjectCommand>
    {
        public CreateJobProjectCommandHandler(IBusHandler bus,
                                              IProjectRepository projectRepository,
                                              IUserRepository userRepository) : base(bus, projectRepository, userRepository)
        {
        }

        protected override Project CreateProject(CreateJobProjectCommand request, List<Theme> themes)
        {
            return new JobProject(request.Title, request.PublicDescription, request.TotalSpots, themes, request.CreatorId, request.JobProjectLevel, request.MemberPayment);
        }
    }
}
