using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<Tid> : Entity<Tid>, IAggregate<Tid>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvents(IDomainEvent domainEvent )
        {
            _domainEvents.Add(domainEvent);
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeueEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeueEvents;
        }
    }
}
