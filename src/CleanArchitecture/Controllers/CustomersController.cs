namespace CleanArchitecture.WebAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Commands.CreateCustomer;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : ApiController
    {
        public CustomersController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateCustomerCommand command)
        {
            return await this.Mediator.Send(command);
        }
    }
}
