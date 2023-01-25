using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
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
            if (request.ThemeCategory == null)
            {
                await Notify(request, "The theme category is necessary");
                return CommandResult.Failure();
            }

            var theme = new Theme(request.Name, request.ThemeCategory.Value);
            var savedTheme = _uow.Projects.GetThemeByName(request.Name);

            if (await savedTheme is not null)
            {
                await Notify(request, "This theme alredy exists.");
                return CommandResult.Failure();
            }

            theme.AddEvent()
            
            _uow.Users.Create(user);

            return await _uow.Commit();

        }
    }
}
