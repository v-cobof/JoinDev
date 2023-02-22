using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using JoinDev.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCommandHandler : BaseCommandHandler<CreateThemeCommand, CommandResult>
    {
        public CreateThemeCommandHandler(IUnitOfWork uow, IBusHandler bus) : base(uow, bus)
        {
        }

        public async override Task<CommandResult> Execute(CreateThemeCommand request)
        {
            if (await ThemeAlredyExists(request.Name))
            {
                await Notify(request, "This theme alredy exists.");
                return CommandResult.Failure();
            }

            var category = await _uow.Projects.GetThemeCategoryById(request.ThemeCategoryId);

            if (category is null)
            {
                await Notify(request, "The theme category was not found.");
                return CommandResult.Failure();
            }

            var theme = new Theme(request.Name, category);
            theme.AddEvent(new ThemeCreatedEvent());
            
            _uow.Projects.CreateTheme(theme);

            return await _uow.Commit();
        }

        private async Task<bool> ThemeAlredyExists(string name)
        {
            var savedTheme = _uow.Projects.GetThemeByName(name);

            return await savedTheme is not null;
        }
    }
}
