using JoinDev.Application.Commands;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Core.Communication.Messages.Queue;
using MassTransit;
using Newtonsoft.Json;

namespace JoinDev.Application.Consumers
{
    public class CommandConsumer : IConsumer<QueueCommand>
    {
        private readonly IMediatorHandler _mediator;

        public CommandConsumer(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<QueueCommand> context)
        {
            var message = context.Message;
            var type = typeof(CommandConsumer).Assembly.GetType($"JoinDev.Application.Commands.{message.MessageType}");

            var command = (IQueueable) JsonConvert.DeserializeObject(message.Content, type);
            command.Queued = true;

            _mediator.SendCommand((Command) command);

            return Task.CompletedTask;
        }
    }
}
