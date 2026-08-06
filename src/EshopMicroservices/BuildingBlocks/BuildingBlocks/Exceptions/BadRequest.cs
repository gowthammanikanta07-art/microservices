using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class BadRequest : Exception
    {
        private string? Details { get; }

        public BadRequest(string message) : base(message)
        {
            
        }
        public BadRequest(string message, string details) : base(message)
        {
            Details = details;
            
        }
    }
}
