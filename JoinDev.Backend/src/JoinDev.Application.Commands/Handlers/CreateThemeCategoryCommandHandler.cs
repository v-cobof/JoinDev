using JoinDev.Application.Events;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCategoryCommandHandler : BaseCommandHandler<CreateThemeCategoryCommand, CommandResult>
    {
        private readonly IThemeCategoryDAO _themeCategoryDAO;

        public CreateThemeCategoryCommandHandler(IThemeCategoryDAO dao, IBusHandler bus) : base(bus)
        {
            _themeCategoryDAO = dao;
        }

        public async override Task<CommandResult> Execute(CreateThemeCategoryCommand request)
        {
            var category = await _themeCategoryDAO.GetThemeCategoryByName(request.Name);

            if(category is not null)
            {
                await Notify(request, "This theme category alredy exists.");
                return CommandResult.Failure();
            }

            var newCategory = new ThemeCategory(request.Name);
            newCategory.AddEvent(new ThemeCategoryCreatedEvent() { Name = request.Name });

            return await _themeCategoryDAO.CreateThemeCategory(newCategory);
        }
    }
}
