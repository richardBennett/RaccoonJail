using System;

namespace Database.Services.Exceptions
{
    public class InmateCrudException : Exception
    {
        public InmateCrudException(string message) : base(message)
        {
        }
    }
}