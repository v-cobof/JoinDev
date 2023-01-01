using JoinDev.Domain.Core.Data;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Data
{
    public interface IProjectRepository : IRepository<Project>
    {
        void Create(Project project);

        Task<Project> GetById(Guid id);
    }
}
