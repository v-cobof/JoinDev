using MediatR;

namespace JoinDev.Domain.Core.Communication.Messages
{
    public abstract class Event : Message, INotification
    {
    }
}
