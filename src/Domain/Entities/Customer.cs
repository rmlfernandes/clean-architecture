namespace CleanArchitecture.Domain.Entities
{
    using System;
    using CleanArchitecture.Domain.Common;
    using CleanArchitecture.Domain.Exceptions;

    public class Customer : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public long? PhoneNumber { get; set; }

        public Uri Website { get; set; }

        public void UpdatePhoneNumber(long phoneNumber)
        {
            if (phoneNumber <= 0)
            {
                throw new InvalidCustomerOperationException($"'{phoneNumber}' is not a valid value for customer phone number.");
            }

            this.PhoneNumber = phoneNumber;
        }

        public void UpdateWebsite(string url)
        {
            if(!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var website))
            {
                throw new InvalidCustomerOperationException($"'{website}' is not a valid value for customer website.");
            }

            this.Website = website;
        }
    }
}
