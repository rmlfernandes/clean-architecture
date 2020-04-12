namespace CleanArchitecture.Application.Common.Exceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string entityName, string id)
            : base($"Entity \"{entityName}\" ({id}) was not found.")
        {
        }
    }
}
