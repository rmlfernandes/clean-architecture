namespace CleanArchitecture.Application.Customers.Commands.DeleteCustomer
{
    using System.Threading;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Common.Interfaces;
    using MediatR;

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            await this.repository.DeleteCustomerAsync(command.Id);

            return Unit.Value;
        }
    }
}
