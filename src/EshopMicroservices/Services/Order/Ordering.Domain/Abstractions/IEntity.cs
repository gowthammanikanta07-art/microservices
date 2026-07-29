using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Abstractions
{
    public interface IEntity<Tid> : IEntity
    {
        public Tid Id { get; set; }
    }
    public interface IEntity
    {
        //common properties in domain
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}
