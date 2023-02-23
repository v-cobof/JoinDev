using JoinDev.Application.Events;
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
    public class CreateThemeCategoryCommandHandler : BaseCommandHandler<CreateThemeCategoryCommand, CommandResult>
    {
        public CreateThemeCategoryCommandHandler(IUnitOfWork uow, IBusHandler bus) : base(uow, bus)
        {
        }

        public async override Task<CommandResult> Execute(CreateThemeCategoryCommand request)
        {
            var category = _uow.Projects.GetThemeCategoryByName(request.Name);

            if(category is not null)
            {
                await Notify(request, "This theme category alredy exists.");
                return CommandResult.Failure();
            }

            var newCategory = new ThemeCategory(request.Name);
            newCategory.AddEvent(new ThemeCategoryCreatedEvent());

            _uow.Projects.CreateThemeCategory(newCategory);
            return await _uow.Commit();
        }
    }
}
