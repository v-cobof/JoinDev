using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Data
{
    public interface IReplicationRepository<T>
    {
        Task Create(T model);

        Task Update(T model); 
    }
}
