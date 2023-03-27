using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCommandHandler : BaseCommandHandler<CreateThemeCommand>
    {
        private readonly IThemeDAO _themeDAO;
        private readonly IThemeCategoryDAO _themeCategoryDAO;

        public CreateThemeCommandHandler(IThemeDAO dao, IThemeCategoryDAO categoryDao, IBusHandler bus) : base(bus)
        {
            _themeDAO = dao;
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
            
            return await _themeDAO.CreateTheme(theme);
        }
    }
}
