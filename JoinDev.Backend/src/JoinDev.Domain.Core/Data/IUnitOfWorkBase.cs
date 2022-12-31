using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Data
{
    public interface IUnitOfWorkBase
    {
        Task<bool> Commit();
    }
}
