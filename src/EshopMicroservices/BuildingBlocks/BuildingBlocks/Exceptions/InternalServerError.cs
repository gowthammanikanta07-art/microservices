using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerError : Exception
    {
        private string? Details {  get; }

        public InternalServerError(String message) : base(message)
        {
            
        }

        public InternalServerError(string message, string details) : base(message)
        {
            Details = details;
            
        }
    }
}
