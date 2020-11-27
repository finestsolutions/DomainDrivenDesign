using System.Collections.Generic;
using FinestSolutions.DomainDrivenDesign.Abstractions.Events;

namespace FinestSolutions.DomainDrivenDesign.Abstractions.Aggregates
{
    public interface IAggregateEvents
    {
        IReadOnlyCollection<IEvent> Events { get; }
        void FlushEvents();
    }
}