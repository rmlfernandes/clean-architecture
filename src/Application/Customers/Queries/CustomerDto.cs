namespace CleanArchitecture.Application.Customers.Queries
{
    using System;

    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public long? PhoneNumber { get; set; }

        public string Website { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
