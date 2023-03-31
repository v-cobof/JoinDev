using JoinDev.Application.Mappers;
using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Validation.Results;
using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Commands.Handlers.Projects
{
    public class FillProjectRestrictedInfoCommandHandler : BaseCommandHandler<FillProjectRestrictedInfoCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public FillProjectRestrictedInfoCommandHandler(IBusHandler bus, IProjectRepository projectRepository) : base(bus)
        {
            _projectRepository = projectRepository;
        }

        public async override Task<CommandResult> Execute(FillProjectRestrictedInfoCommand request)
        {
            var project = await _projectRepository.GetById(request.ProjectId);

            if(project is null)
            {
                await Notify(request, $"The Project with ID {request.ProjectId} does not exist.");
                return CommandResult.Failure();
            }

            var info = new ProjectRestrictedInfo(request.Description, request.ProjectId);
            var links = request.Links.ToLinkEntities().ToList();

            info.SetLinks(links);
            project.SetProjectRestrictedInfo(info);

            _projectRepository.Update(project);
            return await _projectRepository.UnitOfWork.Commit();
        }
    }
}
