namespace CleanArchitecture.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanArchitecture.Application.Customers.Commands.CreateCustomer;
    using CleanArchitecture.Application.Customers.Commands.DeleteCustomer;
    using CleanArchitecture.Application.Customers.Commands.UpdateCustomer;
    using CleanArchitecture.Application.Customers.Queries;
    using CleanArchitecture.Application.Customers.Queries.GetCustomer;
    using CleanArchitecture.Application.Customers.Queries.GetCustomers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : ApiController
    {
        public CustomersController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateCustomerCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveAsync([FromBody] DeleteCustomerCommand command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllAsync([FromQuery] GetCustomersQuery query)
        {
            return await this.Mediator.Send(query);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<CustomerDto>> GetAsync([FromQuery] GetCustomerQuery query)
        {
            return await this.Mediator.Send(query);
        }

        [HttpPost("update")]
        public async Task<ActionResult<CustomerDto>> UpdateAsync([FromBody] UpdateCustomerCommand command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }
    }
}
