using Marten.Internal.ClosedShape;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message):base(message)
        {
            
        }

        public NotFoundException(string message, object key) :
            base($"Not found for {message}{key}")
        {
            
        }
    }
}
