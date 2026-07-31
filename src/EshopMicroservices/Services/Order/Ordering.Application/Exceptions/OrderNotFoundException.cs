using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("Order",id)
        {
            
        }
    }
}
