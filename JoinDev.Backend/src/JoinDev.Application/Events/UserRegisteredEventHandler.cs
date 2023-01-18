using JoinDev.Application.Events.Base;
using JoinDev.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Events
{
    public class UserRegisteredEventHandler : BaseDataReplicationEventHandler<UserRegisteredEvent>
    {
        public override Task Execute(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
