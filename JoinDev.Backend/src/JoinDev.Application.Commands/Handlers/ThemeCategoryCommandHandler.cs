using JoinDev.Application.Events;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateThemeCategoryCommandHandler : BaseCommandHandler<CreateThemeCategoryCommand>
    {
        private readonly IThemeCategoryDAO _themeCategoryDAO;

        public CreateThemeCategoryCommandHandler(IThemeCategoryDAO dao, IBusHandler bus) : base(bus)
        {
            _themeCategoryDAO = dao;
        }

        public async override Task<CommandResult> Execute(CreateThemeCategoryCommand request)
        {
            var newCategory = new ThemeCategory(request.Name);

            newCategory.AddEvent(new ThemeCategoryCreatedEvent(newCategory.Id, newCategory.Name));

            return await _themeCategoryDAO.CreateThemeCategory(newCategory);
        }
    }
}
