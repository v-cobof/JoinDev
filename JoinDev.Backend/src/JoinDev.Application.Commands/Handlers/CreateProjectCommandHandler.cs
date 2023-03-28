using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;
using JoinDev.Domain.Enums;
using JoinDev.Application.Mappers;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateProjectCommandHandler : BaseCommandHandler<CreateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public CreateProjectCommandHandler(IBusHandler bus, IProjectRepository projectRepository, IUserRepository userRepository) : base(bus)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async override Task<CommandResult> Execute(CreateProjectCommand request)
        {
            request.Links.SetAsUserLinks();

            var themes = await _projectRepository.GetThemesByIds(request.ThemesIds);

            if (themes.Count != request.ThemesIds.Count)
            {
                var wrongIds = request.ThemesIds.Where(id => !themes.Any(x => x.Id == id));
                await Notify(request, $"The project can't be created because the following IDs don't exist: {string.Join(", ", wrongIds)}");

                return CommandResult.Failure();
            }

            var creator = _userRepository.GetById(request.CreatorId);

            if(creator is null)
            {
                await Notify(request, $"The project can't be created because the creator doesn't exist.");

                return CommandResult.Failure();
            }

            var project = CreateProject(request, themes);

            _projectRepository.Create(project);
            return await _projectRepository.UnitOfWork.Commit();
        }

        private Project CreateProject(CreateProjectCommand request, List<Theme> themes)
        {
            switch (request.ProjectType)
            {
                case ProjectType.Study:
                    return new StudyProject(request.Title, request.PublicDescription, request.TotalSpots, themes, request.CreatorId, request.StudyProjectLevel);
                case ProjectType.Job:
                    return new JobProject(request.Title, request.PublicDescription, request.TotalSpots, themes, request.CreatorId, request.JobProjectLevel, request.MemberPayment);
                default:
                    return default;
            }
        }
    }
}
