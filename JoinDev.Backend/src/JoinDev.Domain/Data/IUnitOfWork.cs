using JoinDev.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Data
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IUserRepository Users { get; }
        IProjectRepository Projects { get; }
        ICategoryRepository Categories { get; }
    }
}
