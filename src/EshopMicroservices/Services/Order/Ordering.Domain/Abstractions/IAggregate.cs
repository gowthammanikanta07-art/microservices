using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Abstractions
{
    public interface IAggregate<Tid> : IAggregate, IEntity<Tid>
    {

    }
    public interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents  { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
