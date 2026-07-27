using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Abstractions
{
    public abstract class Entity<Tid> : IEntity<Tid>
    {
        public  Tid Id { get; set; }
        public  DateTime? CreatedAt { get; set; }
        public  string? CreatedBy { get; set; }
        public  DateTime? LastModified { get; set; }
        public  string? ModifiedBy { get; set; }
    }
}
