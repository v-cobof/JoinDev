using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCommandHandler : BaseCommandHandler<CreateThemeCommand, CommandResult>
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
            if (await ThemeAlredyExists(request.Name))
            {
                await Notify(request, "This theme alredy exists.");
                return CommandResult.Failure();
            }

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

        private async Task<bool> ThemeAlredyExists(string name)
        {
            var savedTheme = _themeDAO.GetThemeByName(name);

            return await savedTheme is not null;
        }
    }
}
