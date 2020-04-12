namespace CleanArchitecture.Domain.Exceptions
{
    using System;

    public class InvalidCustomerOperationException : Exception
    {
        public InvalidCustomerOperationException(string message)
            : base(message)
        {
        }
    }
}
