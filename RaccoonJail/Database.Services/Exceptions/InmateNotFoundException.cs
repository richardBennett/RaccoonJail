using System;

namespace Database.Services.Exceptions
{
    public class InmateNotFoundException : Exception
    {
        public InmateNotFoundException(long id) : base($"Could not find an Inmate with Id: {id}")
        {
        }
    }
}