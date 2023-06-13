using JoinDev.Application.Models;
using JoinDev.Application.Queries.ViewModels;
using JoinDev.Domain.Core.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Queries
{
    public class ProjectsQuery : Query<List<ProjectDisplayViewModel>>
    {
        public ProjectType? ProjectType { get; set; }
        public List<Guid> ThemesIds { get; set; }
    }
}
