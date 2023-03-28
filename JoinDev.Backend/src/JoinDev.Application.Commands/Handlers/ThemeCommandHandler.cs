using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCommandHandler : BaseCommandHandler<CreateThemeCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IThemeCategoryDAO _themeCategoryDAO;

        public CreateThemeCommandHandler(IProjectRepository repository, IThemeCategoryDAO categoryDao, IBusHandler bus) : base(bus)
        {
            _projectRepository = repository;
            _themeCategoryDAO = categoryDao;
        }

        public async override Task<CommandResult> Execute(CreateThemeCommand request)
        {
            var category = await _themeCategoryDAO.GetThemeCategoryById(request.ThemeCategoryId);

            if (category is null)
            {
                await Notify(request, "The theme category was not found.");
                return CommandResult.Failure();
            }

            var theme = new Theme(request.Name, category);
            theme.AddEvent(new ThemeCreatedEvent());
            
            _projectRepository.CreateTheme(theme);
            return await _projectRepository.UnitOfWork.Commit();
        }
    }
}
