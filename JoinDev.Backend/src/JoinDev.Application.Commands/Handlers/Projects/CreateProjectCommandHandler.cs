using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;
using JoinDev.Domain.Enums;
using JoinDev.Application.Mappers;

namespace JoinDev.Application.Commands.Handlers.Projects
{
    public abstract class CreateProjectCommandHandler<Command> : BaseCommandHandler<Command> where Command : CreateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public CreateProjectCommandHandler(IBusHandler bus, IProjectRepository projectRepository, IUserRepository userRepository) : base(bus)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async override Task<CommandResult> Execute(Command request)
        {
            var themes = await _projectRepository.GetThemesByIds(request.ThemesIds);

            if (themes.Count != request.ThemesIds.Count)
            {
                var wrongIds = request.ThemesIds.Where(id => !themes.Any(x => x.Id == id));
                await Notify(request, $"The project can't be created because the following IDs don't exist: {string.Join(", ", wrongIds)}");
                return CommandResult.Failure();
            }

            var creator = _userRepository.GetById(request.CreatorId);

            if (creator is null)
            {
                await Notify(request, $"The project can't be created because the creator doesn't exist.");
                return CommandResult.Failure();
            }

            var project = CreateProject(request, themes);

            _projectRepository.Create(project);
            return await _projectRepository.UnitOfWork.Commit();
        }

        protected abstract Project CreateProject(Command request, List<Theme> themes);
    }
}
