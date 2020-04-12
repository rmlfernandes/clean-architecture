namespace CleanArchitecture.Domain.Entities
{
    using System;
    using CleanArchitecture.Domain.Common;

    public class Customer : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public long? PhoneNumber { get; set; }

        public Uri Website { get; set; }
    }
}
