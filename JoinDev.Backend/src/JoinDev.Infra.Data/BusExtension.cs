using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Infra.Data
{
    public static class BusExtension
    {
        public static async Task PublishEntityEvents(this IBusHandler bus, JoinDevContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            await bus.PublishNotificationsBatch(domainEvents);
        }
    }
}
