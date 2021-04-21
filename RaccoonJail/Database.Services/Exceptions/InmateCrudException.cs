using System;

namespace Data.Services.Exceptions
{
    public class InmateCrudException : Exception
    {
        public InmateCrudException(string message) : base(message)
        {
        }
    }
}