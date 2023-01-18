using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Events.Base
{
    public abstract class BaseDataReplicationEventHandler<T> : BaseEventHandler<T> where T : Domain.Core.Communication.Messages.Event
    {

    }
}
