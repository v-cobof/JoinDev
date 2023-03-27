using JoinDev.Application.Events;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;

namespace JoinDev.Application.Commands.Handlers
{
    public class CreateLinkSourceCommandHandler : BaseCommandHandler<CreateLinkSourceCommand>
    {
        private readonly ILinkSourceDAO _linkSourceDAO;

        public CreateLinkSourceCommandHandler(ILinkSourceDAO dao, IBusHandler bus) : base(bus)
        {
            _linkSourceDAO = dao;
        }

        public async override Task<CommandResult> Execute(CreateLinkSourceCommand request)
        {
            var source = new LinkSource(request.Name);

            source.AddEvent(new LinkSourceCreatedEvent(source.Id, source.Name));

            return await _linkSourceDAO.CreateLinkSource(source);
        }
    }
}

