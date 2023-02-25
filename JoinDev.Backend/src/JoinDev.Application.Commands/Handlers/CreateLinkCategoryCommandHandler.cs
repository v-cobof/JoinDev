using JoinDev.Application.Events;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateLinkSourceCommandHandler : BaseCommandHandler<CreateLinkSourceCommand, CommandResult>
    {
        private readonly ILinkSourceDAO _linkSourceDAO;

        public CreateLinkSourceCommandHandler(ILinkSourceDAO dao, IBusHandler bus) : base(bus)
        {
            _linkSourceDAO = dao;
        }

        public async override Task<CommandResult> Execute(CreateLinkSourceCommand request)
        {
            var category = await _uow.Projects.GetThemeCategoryByName(request.Name);

            if (category is not null)
            {
                await Notify(request, "This theme category alredy exists.");
                return CommandResult.Failure();
            }

            var newCategory = new ThemeCategory(request.Name);
            newCategory.AddEvent(new ThemeCategoryCreatedEvent() { Name = request.Name });

            _uow.Projects.CreateThemeCategory(newCategory);
            return await _uow.Commit();
        }
    }
}

