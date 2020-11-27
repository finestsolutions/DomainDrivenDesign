using System.Collections.Generic;
using FinestSolutions.DomainDrivenDesign.Abstractions.Entities;
using FinestSolutions.DomainDrivenDesign.Abstractions.Events;

namespace FinestSolutions.DomainDrivenDesign.Abstractions.Aggregates
{
    public abstract class AggregateRoot<TIdentifier> : Entity<TIdentifier>, IAggregateEvents
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        protected void PublishEvent(IEvent @event) => _events.Add(@event);


        // IAggregateEvents
        IReadOnlyCollection<IEvent> IAggregateEvents.Events => _events;
        void IAggregateEvents.FlushEvents() => _events.Clear();
    }
}
